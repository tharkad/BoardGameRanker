import urllib
import re
from PIL import Image
import os.path

target = open("game_ids.txt", 'w')

baseImageURL = "http://cf.geekdo-images.com/images/"

size = 300, 300

for page in range(1,11):
  counter = 1
  link = "https://boardgamegeek.com/browse/boardgame/page/" + str(page)
  f = urllib.urlopen(link)
  myfile = f.readlines()
  linecounter = 0
  while linecounter < len(myfile):
    if 'a name="' + str(counter + ((page - 1) * 100)) in myfile[linecounter]:
        print page, counter + ((page - 1) * 100)
        searchObj = re.search( r'boardgame/(.*?)/', myfile[linecounter + 17], re.M|re.I)
        gameID = searchObj.group(1)
        target.write(gameID + '\n')

        searchObj = re.search( r'src="//cf.geekdo-images.com/images/(.*?)"></a>', myfile[linecounter + 5], re.M|re.I)
        thumbimagename = searchObj.group(1)
        mainimagename = re.sub(r'_mt', "", thumbimagename)

        infile = "bgg-images-large/" + mainimagename
        outfile = "bgg-images-scaled/" + gameID + ".png"

        if (not os.path.isfile(outfile)):
          print "Downloading and scaling " + outfile

          imagelink = baseImageURL + mainimagename
          imagefile = urllib.URLopener()
          imagefile.retrieve(imagelink, "bgg-images-large/" + mainimagename)

          im = Image.open(infile)
          im.thumbnail(size, Image.ANTIALIAS)
          im.save(outfile, "PNG")

        counter += 1
    linecounter += 1