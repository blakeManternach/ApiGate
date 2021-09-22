import json
from json import JSONEncoder
from gate import Gate
import requests


def send(gates):
    # Print Json Formatted data below
    # print(json.dumps(gates, indent=4, cls=GateEncoder))

    # This sets the request to verify=False...this is not safe and opens up the post to middle attacks.
    # Need to get the SSL certificate
    headers = {
        'Content-type': 'application/json',
        'Accept': 'application/json'
    }
    print(requests.post("https://localhost:5001/api/Gate/collection", data=json.dumps(gates, cls=GateEncoder),
                        headers=headers, verify=False))


class GateEncoder(JSONEncoder):
    def default(self, o):
        if isinstance(o, Gate):
            return o.__dict__
        return JSONEncoder.default(self, o)
