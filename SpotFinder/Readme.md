## Execution

Method one:
- add mesh.json path and number of spots in commandline like the following command:
		spotfinder.exe mesh.json 5

Method two:
- Run project local in development mode, a browser with swagger ui will open
-- Select GET, press Try it out and insert your desired amount of View Spots and press execute. Per default this will run over mesh20000.json in Ressources folder
-- Alternative: Select POST, press Try it out and insert your desired amount of View Spots. Insert your Mesh json into request body and press execute.


## Testing
Testing Framework: xUnit

The tests are mostly focused around the core logic of given problem.

## Validation
There is no validation of the mesh. In the current state it's "shit in, shit out".
A valid mesh needs to have the following structure:
{
  "nodes": [
    {
      "id": 0,
      "x": 0.0,
      "y": 0.0
    }
  ],
  "elements": [
    {
      "id": 0,
      "nodes": [
        0
      ]
    }
  ],
  "values": [
    {
      "element_Id": 0,
      "value": 0.0
    }
  ]
}