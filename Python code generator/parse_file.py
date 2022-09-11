import class_gen
import content_gen

def ParseTxt(file_name, folder):
	file = open(file_name, "r")
	
	result = []
	
	name = file_name.replace(".txt", "")
	name = name.title()
	name = name.replace("_", "")
	
	for line in file:
		result.append(line)
	
	result[0] = result[0].replace("# ", "")
	
	if "content" in result[0]:
		content_gen.CreateContentFiles(result, name, folder)
	elif "class" in result[0]:
		class_gen.CreateClassFile(result, name, folder)
	
	file.close()
	return name
