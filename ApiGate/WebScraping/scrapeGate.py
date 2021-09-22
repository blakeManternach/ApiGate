from bs4 import BeautifulSoup
import requests
import gate
import postJSON

'''
TODO: Delete gate class entirely, just send dictionaries that are preformatted.  This way
you don't have to worry about serializing the gate object either.
'''

gates = []


def run():
    html = requests.get(url='https://en.wikipedia.org/wiki/List_of_%22-gate%22_scandals_and_controversies').text
    soup = BeautifulSoup(html, 'html.parser')
    results = soup.find_all("table")
    for table in results:
        handleTable(table)
    postJSON.send(gates)


def handleTable(table):
    tbody = table.contents[1]
    rows = tbody.contents

    # Get Headers
    rowHeadersFiltered = list(filter(lambda e: e != '\n' and 'Reference' not in e.text, rows[0].contents))
    headers = [takeOutNewLineCharacters(e.text) for e in rowHeadersFiltered]
    # print(headers)

    # Get category
    categoryElement = table.find_previous_sibling("h3")
    categoryTitle = categoryElement.next_element

    # Get Gate
    for i in range(1, len(rows)):
        if rows[i] == '\n':
            continue

        # This dictionary will be populated with all attributes and then be turned into a Gate class.
        attributeDict = {"Category": categoryTitle.text}
        tdInnerTexts = list(filter(lambda e: e != '\n', rows[i].contents))
        for j in range(0, len(headers)):
            if tdInnerTexts[j].text == '\n':
                continue

            # If there is a hyperlink in the title, grab the first one available
            if j == 0:
                for e in tdInnerTexts[j].contents:
                    if e.name == 'a':
                        url = 'https://en.wikipedia.org/' + e['href']
                        attributeDict['url'] = url
                        break

            # Adds the appropriate attribute to the appropriate header in or dictionary
            if headers[j] == 'Year':
                attributeDict[headers[j]] = int(takeOutNewLineCharacters(tdInnerTexts[j].text)[:4])
            else:
                attributeDict[headers[j]] = takeOutNewLineCharacters(tdInnerTexts[j].text)

        gates.append(gate.Gate(attributeDict))


def takeOutNewLineCharacters(data):
    if '\n' in data:
        return data.replace("\n", "")
    return data
