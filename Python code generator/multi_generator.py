import glob
import os
import parse_file

folder = raw_input("Enter folder name: ")
print "------------------------ STARTING ------------------------"

try:
	os.chdir("" + folder)
	for files in glob.glob("*.txt"):
		print "Found file: " + files + "..."
		path = os.path.join(files)
		name = parse_file.ParseTxt(path, folder)
		
except Exception as e:
	print "Failed..." + "	" + str(e) + "\n"

print "------------------------ ENDED ------------------------"
raw_input("Waiting")
