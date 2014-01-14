Model files: 

When loading the model files, make sure you unzip ALL files. Whether you add the .fbx files onto your project as a link or directly, make 
sure that the project can read both the .fbx and the .jpgs. If you don't care for linking your .fbx files and are instead adding them 
directly to your project, just add as well all the textures. 

Sun model objects:

The sun model objects have transparency associated with them. To best show the glow of the Sun, you need the following function call

((Model)geometryNode.Model).UseInternalMaterials = true; // Tutorial 2 teaches you when this should be called
((Model)geometryNode.Model).ContainsTransparency = true; // Make sure you add this function after the previous call.

- - - - - - - - - - - - - - - 

Credits: 

The International Space Station and Mars Reconnaisance models (ISSComplete1 and MRO1) were created by NASA Ames Research Center. The planets, moons and suns
were created by Tronitec Game Studios. 

The wedge_p1_diff_v1.tga file is from the XNA tutorial found in the MSDN website. 
