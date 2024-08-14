import xml.etree.ElementTree as ET
from collections import defaultdict

def parse_osm_file(file_path):
    # Parse the XML file
    tree = ET.parse(file_path)
    root = tree.getroot()

    # map to store unique 'v' values
    unique_v_values = defaultdict(int)

    # Iterate through all 'tag' elements
    for tag in root.findall(".//tag"):
        if tag.get('k') == 'highway':
            v_value = tag.get('v')

            if v_value:
                unique_v_values[v_value] += 1

    return unique_v_values

if __name__ == "__main__":
    file_path = r'C:\Users\asoba\AppData\LocalLow\Colossal Order\Cities Skylines II\Heightmaps\osm-data_-97.7406809768546_30.434287095262107_57.344.osm'

    # Parse the file and get unique 'k' and 'v' values
    unique_v_values = parse_osm_file(file_path)

    print("\nUnique 'v' values:")
    for v, count in unique_v_values.items():
        print(f"{v}: {count} times")