def DataBegin(name):
	result = """using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class """ + name + """Data : ContentObject
    {
"""
	return result

def DataEnd():
	result = """	}
}
"""
	return result

def ContentBegin(name):
	result = """ """
	return result

def ContentEnd():
	result = """	}
}
"""
	return result


def ConstructWriteFunction(name, attributes):
	result = """using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using ContentData;

namespace ContentProcessor
{
    [ContentTypeWriter]
    public class """  + name + """DataWriter : ContentDataWriter<""" + name + """Data>
    {
        protected override void Write(ContentWriter output, """ + name + """Data value)
        {
"""
	for a in attributes:
		sp = a.split(" ")
		type = sp[0]
		name = sp[1]
		
		result += """			// """ + type + """ """ + name + """\n"""

	result += """
        }
    }
}
"""
	
	return result

def AddAttributes(attributes):
	result = """"""
		
	for a in attributes: 
		sp = a.split(" ")
		type = sp[0]
		name = sp[1]
		end = ";"
		if "List<" in type:
			end = " = new " + type + "();"
			
		result += "		private " + type + " " + name + end + "\n"
		
	return result
		
def AddGetSet(attributes):
	result = """"""
	
	for a in attributes:
		sp = a.split(" ")
		type = sp[0]
		name = sp[1].title()
		
		result += """		public """ + type + """ """ + name + """
		{
			get { return """ + sp[1] + """; }
			set { """ + sp[1] + """ = value; }
		}
		
"""
	
	return result
	
def AddReaderFunction(name, attributes):
	result = """
		public class """ + name + """DataReader : ContentTypeReader<""" + name + """Data>
        {
            protected override """ + name + """Data Read(ContentReader input,
                """ + name + """Data existingInstance)
            {
                """ + name + """Data desc = existingInstance;
                if (desc == null)
                {
                    desc = new """ + name + """Data();
                }

"""
	for a in attributes:
		sp = a.split(" ")
		tp = sp[0]
		an = sp[1]
		result += """				// """ + tp + """ """ + an + """\n"""
		
				
	result += """
                return desc;
            }
		}
"""
	
	return result

def CreateContentFiles(file, name, folder):
	file_data = open("../" + folder + "/" + name + "Data.cs", "w+")
	file_writer = open("../" + folder + "/" + name + "DataWriter.cs", "w+")

	data_result = DataBegin(name)
	write_result = """"""
	
	# Construct files here
	attributes = []
	
	for line in file:
		if ". " in line:
			cl_line = line.replace(". ", "")
			attributes.append(cl_line)
	
	data_result += AddAttributes(attributes)
	data_result += "\n"
	data_result += AddGetSet(attributes)
	
	data_result += AddReaderFunction(name, attributes)
	write_result += ConstructWriteFunction(name, attributes)
	
	data_result += DataEnd()
	
	file_data.write(data_result)
	file_writer.write(write_result)
	
	file_data.close()
	file_writer.close()
	
	print "Files created successfully for: " + name + "...\n"
	print "=============================\n"