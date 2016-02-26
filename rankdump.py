import urllib
import re

target = open("game_ids.txt", 'w')

for page in range(1,11):
  counter = 1
  link = "https://boardgamegeek.com/browse/boardgame/page/" + str(page)
  f = urllib.urlopen(link)
  myfile = f.readlines()
  linecounter = 0
  while linecounter < len(myfile):
    if 'a name="' + str(counter + ((page - 1) * 100)) in myfile[linecounter]:
        print page, counter + ((page - 1) * 100)
        searchObj = re.search( r'>(.*?)</a>', myfile[linecounter + 17], re.M|re.I)
        print searchObj.group(1)
        counter += 1
    linecounter += 1