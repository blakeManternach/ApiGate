class Gate:
    name = None
    url = None
    year = None
    description = None
    country = None
    category = None

    def __init__(self, attributeDict):
        try:
            self.name = attributeDict["Name"]
        except KeyError:
            pass
        try:
            self.url = attributeDict["url"]
        except KeyError:
            pass
        try:
            self.year = attributeDict["Year"]
        except KeyError:
            pass
        try:
            self.description = attributeDict["Description"]
        except KeyError:
            pass
        try:
            self.country = attributeDict["Country"]
        except KeyError:
            pass
        try:
            self.category = attributeDict["Category"]
        except KeyError:
            pass
        if 'Show' in attributeDict:
            if 'Episode' in attributeDict:
                self.description = attributeDict["Show"] + " (" + attributeDict["Episode"] + "): " + self.description
            else:
                self.description = attributeDict["Show"] + ": " + self.description


