## OSM data resources
https://terraining.ateliernonta.com/
https://www.reddit.com/r/CitiesSkylines2/comments/1atasls/how_to_use_heightmaps_in_map_editor_a_guide/

## OSM Investigation
Just XML with obvious tags.
Will investigate unique type tags

## Original Mod
https://steamcommunity.com/sharedfiles/filedetails/?id=1957515502
https://github.com/grilly86/Open-Cities-Map

## How to mod
https://cs2.paradoxwikis.com/Modding

## Uploading
https://cs2.paradoxwikis.com/Map_Creation#Uploading_a_Map_to_Paradox_Mods


## Actions
Launched City Skylines 2, and opened map editor, then went to options -> modding and installed the moddding toolchain.

I went to unity.com and tried to make an account. I'm having to 'verify' with recapta for 20+ times, so I am giving up on that for now.  need a key
Verified my account using chrome

WAs able to finish the modding toolkit installation on CS2 until I got all green checkboxes

the code is written in c sharp. I copied a helloworld app off the tutorial into a `helloworld.cs`. I went to VS Code extensions and downloaded C# Dev Kit v1.9.55
I then opened a terminal and ran `csc helloworld.cs`

I got a road overlay PNG from https://terraining.ateliernonta.com/ for the same area I wanted to build. I installed a mod to have overlays.

For getting started, I am reading instructions from https://cs2.paradoxwikis.com/Creating_UI_And_Code_Mods

Making the UI mod alongside the code mod. Following along with https://cs2.paradoxwikis.com/Creating_UI_And_Code_Mods#Create_a_UI_Mod_alongside_your_Code_Mod
- I `cd` into `source/RealCitiesRoadImport` and ran `npx create-csii-ui-mod` with the name 'RealCitiesRoadImportUIMod'
- In `mod.json`, I checked to make sure the id matched the code mod name.
- Added the following to the bottom of the `project` tag in the code mod `.csproj` file.
    ```
    <Target Name="BuildUI" AfterTargets="AfterBuild">
		<Exec Command="npm run build" WorkingDirectory="$(ProjectDir)/RealCitiesRoadImportUIMod" />
	</Target>
    ```
- I did not yet add all the lines that I see in the results screenshot in https://cs2.paradoxwikis.com/Creating_UI_And_Code_Mods#Create_a_UI_Mod_alongside_your_Code_Mod 
    - Specifically the `CopyUIFiles` target after `DeployWIP`
    


## Design


1. Parsing OSM Data:

    Read the XML: Use C#'s XmlDocument or XDocument to read and parse the OSM XML file.
    Extract Relevant Data: You'll need to focus on <node> and <way> elements, which represent points and roads respectively. Extract the latitude, longitude, and the list of nodes that make up each road.

2. Converting OSM Coordinates to In-Game Coordinates:

    Projection and Conversion: City Skylines uses a different coordinate system than OSM's latitude/longitude. You'll need to convert these coordinates to match the in-game system, which might involve projecting the lat/long to a flat coordinate system and scaling them appropriately.

    There are a few tags that stand out to me as important

    motorway: 330 times
    motorway_link: 335 times
    secondary: 1525 times
    primary: 371 times
    primary_link: 67 times
    residential: 3290 times
    service: 13074 times
    trunk_link: 8 times
    tertiary: 958 times
    proposed: 9 times
    footway: 9761 times
    path: 686 times
    track: 112 times
    cycleway: 222 times
    trunk: 29 times
    tertiary_link: 65 times
    steps: 54 times
    pedestrian: 13 times

3. Placing Roads in the City Skylines 2 Editor:

    Road Placement API: Use the City Skylines 2 modding API to create road objects in the game. You'll need to figure out how to instantiate road objects and set their positions according to the converted coordinates.

4. Integration with City Skylines 2:

    Load Mod into Game: Integrate your mod with the game so that it can access the OSM data, perform the necessary conversions, and place the roads on the map.

5. Testing and Debugging:

    Test in Editor: Load your mod in the City Skylines 2 editor and test the road placements. Debug any issues with coordinate conversion or road placement.
    Error Handling: Make sure to handle cases where the OSM data might be incomplete or have errors.

6. User Interface:

    UI for Mod Options: Consider adding a UI to let users select the OSM file or customize how the roads are imported.