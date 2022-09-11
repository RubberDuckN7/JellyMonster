def ClassBegin(name):
	result = """using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using IrisEngine;

namespace Jelly_Monster
{
    public  class """ + name + """
    {
"""
	return result
	
def ClassEnd():
	result = """	}
}"""
	return result

def AddAttributes(attributes):
	result = """\n"""
	
	for a in attributes:
		a = a.replace("\n", "")
		sp = a.split(" ")
		type = sp[0]
		name = sp[1]
		scope = sp[2]
		result += """		"""  + type + """ """ + name + """;\n"""
	
	result += "\n"
	return result

def AddGetSet(attributes):
	result = """\n"""
	
	for a in attributes:
		sp = a.split(" ")
		type = sp[0]
		name = sp[1]
		scope = sp[2]
	
		result += """		public """ + type + """ """ + name.title() + """
		{
			get { return """ + name + """; }
			set { """ + name + """ = value; }
		}
		
"""
	
	return result	
	
	
def CreateClassFile(file, name, folder):
	file_out = open("../" + folder + "/" + name + ".cs", "w+")
	final = ClassBegin(name)
	
	attributes = []
	for line in file:
		if ". " in line:
			cl_line = line.replace(". ", "")
			attributes.append(cl_line)
	
	final += AddAttributes(attributes)
	final += """		public """ + name + """()
		{
		
		}
		"""
	final += AddGetSet(attributes)
	
	final += ClassEnd()
	file_out.write(final)
	file_out.close()
	print "File created successfully: " + name + "...\n"
	print "=============================\n"
		