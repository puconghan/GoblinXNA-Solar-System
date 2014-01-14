using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using GoblinXNA;
using GoblinXNA.Graphics;
using GoblinXNA.Graphics.Geometry;
using GoblinXNA.SceneGraph;
using Model = GoblinXNA.Graphics.Model;
using GoblinXNA.Device.Generic;
using GoblinXNA.Physics;
using GoblinXNA.Physics.Newton1;
using GoblinXNA.UI.UI2D;
using GoblinXNA.UI;

namespace SolarSystem
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        // A scene graph used to render virtual reality.
        Scene scene;
        SpriteFont textFont, textFont1, textFont2, textFont3, textFont4;

        GeometryNode mySun, myEarth, myJupiter, myMars, myMercury, myMoon;
        SynchronizedGeometryNode cylinderNode, coneNode, boxNode, torusNode;

        TransformNode mySunRotationParentNode;
        TransformNode myEarthRotationParentNode1, myEarthRotationParentNode2;
        TransformNode myMoonRotationParentNode1, myMoonRotationParentNode2, myMoonRotationParentNode3, myMoonRotationParentNode4;
        TransformNode myMercuryRotationParentNode1, myMercuryRotationParentNode2;
        TransformNode myMarsRotationParentNode1, myMarsRotationParentNode2;
        TransformNode myJupiterRotationParentNode1, myJupiterRotationParentNode2;
        TransformNode cylinderRotationParentNode;
        TransformNode coneRotationParentNode;
        TransformNode torusRotationParentNode;
        TransformNode boxRotationParentNode;
        TransformNode myCameraNode, myCameraNode1, myCameraNode2;
        TransformNode earthControlPanel, mercuryControlPanel, marsControlPanel, jupiterControlPanel, moonControlPanel, cylinderControlPanel, boxControlPanel, torusControlPanel, coneControlPanel;
        TransformNode earthControlPanel1, mercuryControlPanel1, marsControlPanel1, jupiterControlPanel1, moonControlPanel1, cylinderControlPanel1, boxControlPanel1, torusControlPanel1, coneControlPanel1;
        TransformNode earthControlPanel2, mercuryControlPanel2, marsControlPanel2, jupiterControlPanel2, moonControlPanel2, cylinderControlPanel2, boxControlPanel2, torusControlPanel2, coneControlPanel2;
        TransformNode cylinderRotateSunNode, boxRotateSunNode, torusRotateSunNode, coneRotateSunNode;
        SpriteBatch spriteBatch;
        // Now assign this camera to a camera node, and add this camera node to our scene graph.
        CameraNode cameraNode;
        // Create the main panel which holds all other GUI components.
        G2DPanel planetFrame, dubrisFrame;

        static float rotationRate = 1;
        float mySunRotationAngle = 0;
        float myEarthRotationAngle = 0;
        float myMercuryRotationAngle = 0;
        float myMarsRotationAngle = 0;
        float myJupiterRotationAngle = 0;
        float myMoonRotationAngle = 0;
        float myCylinderRotatiionAngle = 0;
        float myConeRotatiionAngle = 0;
        float myTorusRotatiionAngle = 0;
        float myBoxRotatiionAngle = 0;
        float myMoonFreezeEarthRotationAngle = 0;
        int flag = 0;
        float cameraX = 0;
        float cameraY = 0;
        float cameraZ = 0;
        float cameraFieldY = 60;
        String rotationAxis = "";
        String rotationDirection = "";
        int rotationSpeed = 0;
        ButtonGroup group1, group2;
        G2DSlider slider, slider1;
        String label = "Nothing is selected";
        String quitLabel = "Press 'Esc' or click 'Quit' to exit selection mode.";
        float controlPanelEarthRateClockwiseX, controlPanelMercuryRateClockwiseX, controlPanelMarsRateClockwiseX, controlPanelJupiterRateClockwiseX, controlPanelMoonRateClockwiseX, controlPanelConeRateClockwiseX, controlPanelCylinderRateClockwiseX, controlPanelBoxRateClockwiseX, controlPanelTorusRateClockwiseX;
        float controlPanelEarthRateClockwiseY, controlPanelMercuryRateClockwiseY, controlPanelMarsRateClockwiseY, controlPanelJupiterRateClockwiseY, controlPanelMoonRateClockwiseY, controlPanelConeRateClockwiseY, controlPanelCylinderRateClockwiseY, controlPanelBoxRateClockwiseY, controlPanelTorusRateClockwiseY;
        float controlPanelEarthRateClockwiseZ, controlPanelMercuryRateClockwiseZ, controlPanelMarsRateClockwiseZ, controlPanelJupiterRateClockwiseZ, controlPanelMoonRateClockwiseZ, controlPanelConeRateClockwiseZ, controlPanelCylinderRateClockwiseZ, controlPanelBoxRateClockwiseZ, controlPanelTorusRateClockwiseZ;
        float controlPanelEarthRateCounterclockwiseX, controlPanelMercuryRateCounterclockwiseX, controlPanelMarsRateCounterclockwiseX, controlPanelJupiterRateCounterclockwiseX, controlPanelMoonRateCounterclockwiseX, controlPanelConeRateCounterclockwiseX, controlPanelCylinderRateCounterclockwiseX, controlPanelBoxRateCounterclockwiseX, controlPanelTorusRateCounterclockwiseX;
        float controlPanelEarthRateCounterclockwiseY, controlPanelMercuryRateCounterclockwiseY, controlPanelMarsRateCounterclockwiseY, controlPanelJupiterRateCounterclockwiseY, controlPanelMoonRateCounterclockwiseY, controlPanelConeRateCounterclockwiseY, controlPanelCylinderRateCounterclockwiseY, controlPanelBoxRateCounterclockwiseY, controlPanelTorusRateCounterclockwiseY;
        float controlPanelEarthRateCounterclockwiseZ, controlPanelMercuryRateCounterclockwiseZ, controlPanelMarsRateCounterclockwiseZ, controlPanelJupiterRateCounterclockwiseZ, controlPanelMoonRateCounterclockwiseZ, controlPanelConeRateCounterclockwiseZ, controlPanelCylinderRateCounterclockwiseZ, controlPanelBoxRateCounterclockwiseZ, controlPanelTorusRateCounterclockwiseZ;
        Boolean dubrisEscape = false;
        float dubrisEscapeRate1, dubrisEscapeRate2, dubrisEscapeRate3, dubrisEscapeRate4 = 0;
        Boolean earthRotateX, moonRotateX, mercuryRotateX, marsRotateX, jupiterRotateX, cylinderRotateX, coneRotateX, boxRotateX, torusRotateX = false;
        Boolean earthRotateY, moonRotateY, mercuryRotateY, marsRotateY, jupiterRotateY, cylinderRotateY, coneRotateY, boxRotateY, torusRotateY = false;
        Boolean earthRotateZ, moonRotateZ, mercuryRotateZ, marsRotateZ, jupiterRotateZ, cylinderRotateZ, coneRotateZ, boxRotateZ, torusRotateZ = false;
        float earthRotationSpeed1, moonRotationSpeed1, marsRotationSpeed1, jupiterRotationSpeed1, mercuryRotationSpeed1, cylinderRotationSpeed1, coneRotationSpeed1, torusRotationSpeed1, boxRotationSpeed1;
        float earthRotationSpeed2, moonRotationSpeed2, marsRotationSpeed2, jupiterRotationSpeed2, mercuryRotationSpeed2, cylinderRotationSpeed2, coneRotationSpeed2, torusRotationSpeed2, boxRotationSpeed2;
        float earthRotationSpeed3, moonRotationSpeed3, marsRotationSpeed3, jupiterRotationSpeed3, mercuryRotationSpeed3, cylinderRotationSpeed3, coneRotationSpeed3, torusRotationSpeed3, boxRotationSpeed3;
        float valueX = 0;
        float valueY = 0;
        float valueZ = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
#if WINDOWS
            // Display the mouse cursor
            this.IsMouseVisible = true;
#endif
            // Initialize the GoblinXNA framework.
            State.InitGoblin(graphics, Content, "");
            // Initialize the scene graph.
            scene = new Scene();
            // Set the background color to CornflowerBlue color.
            scene.BackgroundColor = Color.Black;
            //Newton physics engine for processing the intersection of cast rays with 3D objects to detect object selection.
            scene.PhysicsEngine = new NewtonPhysics();
            // Set up the lights used in the scene.
            CreateLights();
            // Set up the camera which defines the eye location and viewing frustum.
            CreateCamera();
            // Create 3D objects
            CreateObjects();
            // Create 2D GUI for camera control.
            CreateSolar2DGUI();
            // Create 2D GUI for planet control.
            CreatePlanet2DGUI();
            // Make the 2D GUI for planet control invisiable.
            planetFrame.Visible = false;
            // Create 2D GUI for dubris control.
            CreateDubris2DGUI();
            // Make the 2D GUI for dubris control invisiable.
            dubrisFrame.Visible = false;
            // Add a mouse click callback function.
            MouseInput.Instance.MouseClickEvent += new HandleMouseClick(MouseClickHandler);
            // Add a key click callback function.
            KeyboardInput.Instance.KeyPressEvent += new HandleKeyPress(KeyPressHandler);
        }

        private void CreateLights()
        {
            // Create two directional light sources.
            LightSource lightSource1 = new LightSource();
            lightSource1.Direction = new Vector3(-1, -1, -1);
            lightSource1.Diffuse = Color.White.ToVector4();
            lightSource1.Specular = new Vector4(0.6f, 0.6f, 0.6f, 1);
            
            LightSource lightSource2 = new LightSource();
            lightSource2.Direction = new Vector3(1, 1, -1);
            lightSource2.Diffuse = Color.White.ToVector4()*.12f;
            lightSource2.Specular = new Vector4(0.6f, 0.6f, 0.6f, 1);

            // Create a light node to hold the light source.
            LightNode lightNode = new LightNode();
            lightNode.LightSource = lightSource1;

            LightNode lightNode2 = new LightNode();
            lightNode2.LightSource = lightSource2;

            // Add this light node to the root node.
            scene.RootNode.AddChild(lightNode);
            scene.RootNode.AddChild(lightNode2);
        }

        private void CreateCamera()
        {
            // Create a camera 
            Camera camera = new Camera();
            // Put the camera at (0,0,5)
            camera.Translation = new Vector3(0, 0, 5);
            // Set the vertical field of view to be 60 degrees
            camera.FieldOfViewY = MathHelper.ToRadians(60);
            // Set the near clipping plane to be 0.1f unit away from the camera
            camera.ZNearPlane = 0.1f;
            // Set the far clipping plane to be 1000 units away from the camera
            camera.ZFarPlane = 1000;

            myCameraNode = new TransformNode();
            myCameraNode.Translation = Vector3.Zero;
            myCameraNode1 = new TransformNode();
            myCameraNode1.Translation = Vector3.Zero;
            myCameraNode2 = new TransformNode();
            myCameraNode2.Translation = Vector3.Zero;

            cameraNode = new CameraNode(camera);
            
            scene.RootNode.AddChild(myCameraNode);
            myCameraNode.AddChild(myCameraNode1);
            myCameraNode1.AddChild(myCameraNode2);
            myCameraNode2.AddChild(cameraNode);

            // Assign the camera node to be our scene graph's current camera node
            scene.CameraNode = cameraNode;
        }

        private void CreateObjects()
        {
            // Loads a textured model of the Sun.
            ModelLoader loader = new ModelLoader();
            Model mySunModel = (Model)loader.Load("", "sun1");

            // Loaded Sun model to the geometry node mySun
            mySun = new GeometryNode("Sun");
            mySun.Model = mySunModel;

            mySun.Material.Diffuse = new Vector4(mySun.Material.Diffuse.X, mySun.Material.Diffuse.Y, mySun.Material.Diffuse.Z, 0.7f);

            // Use its internal materials
            ((Model)mySun.Model).UseInternalMaterials = true;
            ((Model)mySun.Model).ContainsTransparency = true;
            //Transforme node for the Sun node.
            TransformNode mySunTransNode = new TransformNode();
            mySunTransNode.Translation = new Vector3(0, 0, 0);
            mySunTransNode.Scale = new Vector3(0.01f, 0.01f, 0.01f);
            //mySunTransNode.Rotation = Quaternion.CreateFromAxisAngle(new Vector3(1, 0, 0), MathHelper.ToRadians(90));

            mySunRotationParentNode = new TransformNode();
            mySunRotationParentNode.Translation = Vector3.Zero;

            mySun.Physics.Pickable = true;
            mySun.AddToPhysicsEngine = true;

            // Loads a textured model of the Earth.
            Model myEarthModel = (Model)loader.Load("", "planet2");

            // Loaded Sun model to the geometry node myEarth
            myEarth = new GeometryNode("Earth");
            myEarth.Model = myEarthModel;

            // Use its internal materials
            ((Model)myEarth.Model).UseInternalMaterials = true;
            //Transforme node for the Earth node.
            TransformNode myEarthTransNode = new TransformNode();
            myEarthTransNode.Translation = new Vector3(0, 0, 2);
            myEarthTransNode.Scale = new Vector3(0.003f, 0.003f, 0.003f);

            myEarthRotationParentNode1 = new TransformNode();
            myEarthRotationParentNode1.Translation = Vector3.Zero;
            myEarthRotationParentNode2 = new TransformNode();
            myEarthRotationParentNode2.Translation = Vector3.Zero;
            earthControlPanel = new TransformNode();
            earthControlPanel.Translation = Vector3.Zero;
            earthControlPanel1 = new TransformNode();
            earthControlPanel1.Translation = Vector3.Zero;
            earthControlPanel2 = new TransformNode();
            earthControlPanel2.Translation = Vector3.Zero;

            myEarth.Physics.Pickable = true;
            myEarth.AddToPhysicsEngine = true;

            // Loads a textured model of the Moon.
            Model myMoonModel = (Model)loader.Load("", "moon1");

            // Loaded Sun model to the geometry node myMoon
            myMoon = new GeometryNode("Moon");
            myMoon.Model = myMoonModel;

            // Use its internal materials
            ((Model)myMoon.Model).UseInternalMaterials = true;
            //Transforme node for the Moon node.
            TransformNode myMoonTransNode = new TransformNode();
            myMoonTransNode.Translation = new Vector3(0, 0, (float)0.5);
            myMoonTransNode.Scale = new Vector3(0.0008f, 0.0008f, 0.0008f);

            myMoonRotationParentNode1 = new TransformNode();
            myMoonRotationParentNode1.Translation = Vector3.Zero;
            myMoonRotationParentNode2 = new TransformNode();
            myMoonRotationParentNode2.Translation = Vector3.Zero;
            myMoonRotationParentNode3 = new TransformNode();
            myMoonRotationParentNode3.Translation = Vector3.Zero;
            myMoonRotationParentNode4 = new TransformNode();
            myMoonRotationParentNode4.Translation = Vector3.Zero;
            moonControlPanel = new TransformNode();
            moonControlPanel.Translation = Vector3.Zero;
            moonControlPanel1 = new TransformNode();
            moonControlPanel1.Translation = Vector3.Zero;
            moonControlPanel2 = new TransformNode();
            moonControlPanel2.Translation = Vector3.Zero;

            myMoon.Physics.Pickable = true;
            myMoon.AddToPhysicsEngine = true;

            // Loads a textured model of the Mercury.
            Model myMercuryModel = (Model)loader.Load("", "planet4");

            // Loaded Sun model to the geometry node myMercury
            myMercury = new GeometryNode("Mercury");

            myMercury.Model = myMercuryModel;
            // Use its internal materials
            ((Model)myMercury.Model).UseInternalMaterials = true;
            //Transforme node for the Mercury node.
            TransformNode myMercuryTransNode = new TransformNode();
            myMercuryTransNode.Translation = new Vector3(0, 0, 1);
            myMercuryTransNode.Scale = new Vector3(0.001f, 0.001f, 0.001f);

            myMercuryRotationParentNode1 = new TransformNode();
            myMercuryRotationParentNode1.Translation = Vector3.Zero;
            myMercuryRotationParentNode2 = new TransformNode();
            myMercuryRotationParentNode2.Translation = Vector3.Zero;
            mercuryControlPanel = new TransformNode();
            mercuryControlPanel.Translation = Vector3.Zero;
            mercuryControlPanel1 = new TransformNode();
            mercuryControlPanel1.Translation = Vector3.Zero;
            mercuryControlPanel2 = new TransformNode();
            mercuryControlPanel2.Translation = Vector3.Zero;

            myMercury.Physics.Pickable = true;
            myMercury.AddToPhysicsEngine = true;

            // Loads a textured model of the Mars.
            Model myMarsModel = (Model)loader.Load("", "planet3");

            // Loaded Sun model to the geometry node myMars
            myMars = new GeometryNode("Mars");
            myMars.Model = myMarsModel;

            // Use its internal materials
            ((Model)myMars.Model).UseInternalMaterials = true;
            //Transforme node for the Mars node.
            TransformNode myMarsTransNode = new TransformNode();
            myMarsTransNode.Translation = new Vector3(0, 0, 3);
            myMarsTransNode.Scale = new Vector3(0.0015f, 0.0015f, 0.0015f);

            myMarsRotationParentNode1 = new TransformNode();
            myMarsRotationParentNode1.Translation = Vector3.Zero;
            myMarsRotationParentNode2 = new TransformNode();
            myMarsRotationParentNode2.Translation = Vector3.Zero;
            marsControlPanel = new TransformNode();
            marsControlPanel.Translation = Vector3.Zero;
            marsControlPanel1 = new TransformNode();
            marsControlPanel1.Translation = Vector3.Zero;
            marsControlPanel2 = new TransformNode();
            marsControlPanel2.Translation = Vector3.Zero;

            myMars.Physics.Pickable = true;
            myMars.AddToPhysicsEngine = true;

            // Loads a textured model of the myJupiter.
            Model myJupiterModel = (Model)loader.Load("", "planet1");

            // Loaded Sun model to the geometry node myJupiter
            myJupiter = new GeometryNode("Jupiter");
            myJupiter.Model = myJupiterModel;

            // Use its internal materials
            ((Model)myJupiter.Model).UseInternalMaterials = true;
            //Transforme node for the Jupiter box node.
            TransformNode myJupiterTransNode = new TransformNode();
            myJupiterTransNode.Translation = new Vector3(0, 0, 4);
            myJupiterTransNode.Scale = new Vector3(0.004f, 0.004f, 0.004f);

            myJupiterRotationParentNode1 = new TransformNode();
            myJupiterRotationParentNode1.Translation = Vector3.Zero;
            myJupiterRotationParentNode2 = new TransformNode();
            myJupiterRotationParentNode2.Translation = Vector3.Zero;
            jupiterControlPanel = new TransformNode();
            jupiterControlPanel.Translation = Vector3.Zero;
            jupiterControlPanel1 = new TransformNode();
            jupiterControlPanel1.Translation = Vector3.Zero;
            jupiterControlPanel2 = new TransformNode();
            jupiterControlPanel2.Translation = Vector3.Zero;

            myJupiter.Physics.Pickable = true;
            myJupiter.AddToPhysicsEngine = true;

            //Space Debris Fields
            //Create a geometry node with a model of cylinder.
            cylinderNode = new SynchronizedGeometryNode("Dubris-Cylinder");
            cylinderNode.Model = new Cylinder(1.5f, 1.5f, 4f, 20);
            //Initializing materials for cylinder.
            Material cylinderMat = new Material();
            cylinderMat.Diffuse = Color.Indigo.ToVector4();
            cylinderMat.Specular = Color.White.ToVector4();
            cylinderMat.SpecularPower = 4;
            //Set cylinder materials
            cylinderNode.Material = cylinderMat;
            //Transforme node for the cylinder node.
            TransformNode cylinderTransNode = new TransformNode();
            cylinderTransNode.Scale = new Vector3(0.03f, 0.03f, 0.03f);
            cylinderTransNode.Rotation = Quaternion.CreateFromAxisAngle(new Vector3(1, 0, 0), MathHelper.ToRadians(60));
            cylinderTransNode.Translation = new Vector3(0, (float) 0.6, 3);

            cylinderRotationParentNode = new TransformNode();
            cylinderRotationParentNode.Translation = Vector3.Zero;
            cylinderRotationParentNode = new TransformNode();
            cylinderControlPanel = new TransformNode();
            cylinderControlPanel.Translation = Vector3.Zero;
            cylinderControlPanel1 = new TransformNode();
            cylinderControlPanel1.Translation = Vector3.Zero;
            cylinderControlPanel2 = new TransformNode();
            cylinderControlPanel2.Translation = Vector3.Zero;
            cylinderRotateSunNode = new TransformNode();
            cylinderRotateSunNode.Translation = Vector3.Zero;

            cylinderNode.Physics.Pickable = true;
            cylinderNode.AddToPhysicsEngine = true;

            // Create a geometry node with a model of cone.
            coneNode = new SynchronizedGeometryNode("Dubris-Cone");
            coneNode.Model = new Cylinder(1.5f, 0, 4f, 20);
            //Initializing materials for cone.
            Material coneMat = new Material();
            coneMat.Diffuse = Color.Lime.ToVector4();
            coneMat.Specular = Color.White.ToVector4();
            coneMat.SpecularPower = 5;
            coneNode.Material = coneMat;
            //Transforme node for the cone node.
            TransformNode coneTransNode = new TransformNode();
            coneTransNode.Scale = new Vector3(0.03f, 0.03f, 0.03f);
            coneTransNode.Rotation = Quaternion.CreateFromAxisAngle(new Vector3(1, 1, 0), MathHelper.ToRadians(45));
            coneTransNode.Translation = new Vector3(0, (float)0.4, (float)3.2);

            coneRotationParentNode = new TransformNode();
            coneRotationParentNode.Translation = Vector3.Zero;
            coneControlPanel = new TransformNode();
            coneControlPanel.Translation = Vector3.Zero;
            coneControlPanel1 = new TransformNode();
            coneControlPanel1.Translation = Vector3.Zero;
            coneControlPanel2 = new TransformNode();
            coneControlPanel2.Translation = Vector3.Zero;
            coneRotateSunNode = new TransformNode();
            coneRotateSunNode.Translation = Vector3.Zero;

            coneNode.Physics.Pickable = true;
            coneNode.AddToPhysicsEngine = true;

            // Create a geometry node with a model of torus.
            torusNode = new SynchronizedGeometryNode("Dubris-Torus");
            torusNode.Model = new Torus(0.7f, 1.5f, 30, 30);
            //Initializing materials for torus.
            Material torusMat = new Material();
            torusMat.Diffuse = Color.Magenta.ToVector4();
            torusMat.Specular = Color.White.ToVector4();
            torusMat.SpecularPower = 10;
            torusNode.Material = torusMat;
            //Transforme node for the torus node.
            TransformNode torusTransNode = new TransformNode();
            torusTransNode.Scale = new Vector3(0.03f, 0.03f, 0.03f);
            torusTransNode.Translation = new Vector3(0, (float)0.6, (float)3.4);
            torusTransNode.Rotation = Quaternion.CreateFromAxisAngle(new Vector3(0, 0, 1), MathHelper.ToRadians(60));

            torusRotationParentNode = new TransformNode();
            torusRotationParentNode.Translation = Vector3.Zero;
            torusControlPanel = new TransformNode();
            torusControlPanel.Translation = Vector3.Zero;
            torusControlPanel1 = new TransformNode();
            torusControlPanel1.Translation = Vector3.Zero;
            torusControlPanel2 = new TransformNode();
            torusControlPanel2.Translation = Vector3.Zero;
            torusRotateSunNode = new TransformNode();
            torusRotateSunNode.Translation = Vector3.Zero;

            torusNode.Physics.Pickable = true;
            torusNode.AddToPhysicsEngine = true;

            // Create a geometry node with a model of box
            boxNode = new SynchronizedGeometryNode("Dubris-Box");
            boxNode.Model = new Box(1, 4, 4);
            //Initiallizing materials for box.
            Material boxMat = new Material();
            boxMat.Diffuse = Color.Crimson.ToVector4();
            boxMat.Specular = Color.White.ToVector4();
            boxMat.SpecularPower = 5;
            boxNode.Material = boxMat;
            //Transforme node for the box node.
            TransformNode boxTransNode = new TransformNode();
            boxTransNode.Scale = new Vector3(0.03f, 0.03f, 0.03f);
            boxTransNode.Translation = new Vector3(0, (float)0.45, (float)3.3);
            boxTransNode.Rotation = Quaternion.CreateFromAxisAngle(new Vector3(0, 0, 1), MathHelper.ToRadians(30));

            boxRotationParentNode = new TransformNode();
            boxRotationParentNode.Translation = Vector3.Zero;
            boxControlPanel = new TransformNode();
            boxControlPanel.Translation = Vector3.Zero;
            boxControlPanel1 = new TransformNode();
            boxControlPanel1.Translation = Vector3.Zero;
            boxControlPanel2 = new TransformNode();
            boxControlPanel2.Translation = Vector3.Zero;
            boxRotateSunNode = new TransformNode();
            boxRotateSunNode.Translation = Vector3.Zero;

            boxNode.Physics.Pickable = true;
            boxNode.AddToPhysicsEngine = true;

            //Add the Sun node to the scene graph
            scene.RootNode.AddChild(mySunRotationParentNode);
            mySunRotationParentNode.AddChild(mySunTransNode);
            mySunTransNode.AddChild(mySun);
            //Add the Earth node to the scene graph
            scene.RootNode.AddChild(myEarthRotationParentNode1);
            myEarthRotationParentNode1.AddChild(myEarthTransNode);
            myEarthTransNode.AddChild(myEarthRotationParentNode2);
            myEarthRotationParentNode2.AddChild(earthControlPanel);
            earthControlPanel.AddChild(earthControlPanel1);
            earthControlPanel1.AddChild(earthControlPanel2);
            earthControlPanel2.AddChild(myEarth);
            //Add the Mercury to the scene graph
            scene.RootNode.AddChild(myMercuryRotationParentNode1);
            myMercuryRotationParentNode1.AddChild(myMercuryTransNode);
            myMercuryTransNode.AddChild(myMercuryRotationParentNode2);
            myMercuryRotationParentNode2.AddChild(mercuryControlPanel);
            mercuryControlPanel.AddChild(mercuryControlPanel1);
            mercuryControlPanel1.AddChild(mercuryControlPanel2);
            mercuryControlPanel2.AddChild(myMercury);
            //Add the Mars to the scene graph
            scene.RootNode.AddChild(myMarsRotationParentNode1);
            myMarsRotationParentNode1.AddChild(myMarsTransNode);
            myMarsTransNode.AddChild(myMarsRotationParentNode2);
            myMarsRotationParentNode2.AddChild(marsControlPanel);
            marsControlPanel.AddChild(marsControlPanel1);
            marsControlPanel1.AddChild(marsControlPanel2);
            marsControlPanel2.AddChild(myMars);
            //Add the Jupiter node to the scene graph
            scene.RootNode.AddChild(myJupiterRotationParentNode1);
            myJupiterRotationParentNode1.AddChild(myJupiterTransNode);
            myJupiterTransNode.AddChild(myJupiterRotationParentNode2);
            myJupiterRotationParentNode2.AddChild(jupiterControlPanel);
            jupiterControlPanel.AddChild(jupiterControlPanel1);
            jupiterControlPanel1.AddChild(jupiterControlPanel2);
            jupiterControlPanel2.AddChild(myJupiter);
            //Add the Moon node to the scene graph
            scene.RootNode.AddChild(myMoonRotationParentNode1);
            myMoonRotationParentNode1.AddChild(myMoonRotationParentNode2);
            myMoonRotationParentNode2.AddChild(myMoonRotationParentNode3);
            myMoonRotationParentNode3.AddChild(myMoonTransNode);
            myMoonTransNode.AddChild(myMoonRotationParentNode4);
            myMoonRotationParentNode4.AddChild(moonControlPanel);
            moonControlPanel.AddChild(moonControlPanel1);
            moonControlPanel1.AddChild(moonControlPanel2);
            moonControlPanel2.AddChild(myMoon);
            //Add the cylinder node to the scene graph
            scene.RootNode.AddChild(cylinderRotationParentNode);
            cylinderRotationParentNode.AddChild(cylinderTransNode);
            cylinderTransNode.AddChild(cylinderControlPanel);
            cylinderControlPanel.AddChild(cylinderControlPanel1);
            cylinderControlPanel1.AddChild(cylinderControlPanel2);
            cylinderControlPanel2.AddChild(cylinderRotateSunNode);
            cylinderRotateSunNode.AddChild(cylinderNode);
            //Add the cone node to the scene graph
            scene.RootNode.AddChild(coneRotationParentNode);
            coneRotationParentNode.AddChild(coneTransNode);
            coneTransNode.AddChild(coneControlPanel);
            coneControlPanel.AddChild(coneControlPanel1);
            coneControlPanel1.AddChild(coneControlPanel2);
            coneControlPanel2.AddChild(coneRotateSunNode);
            coneRotateSunNode.AddChild(coneNode);
            //Add the torus node to the scene graph
            scene.RootNode.AddChild(torusRotationParentNode);
            torusRotationParentNode.AddChild(torusTransNode);
            torusTransNode.AddChild(torusControlPanel);
            torusControlPanel.AddChild(torusControlPanel1);
            torusControlPanel1.AddChild(torusControlPanel2);
            torusControlPanel2.AddChild(torusRotateSunNode);
            torusRotateSunNode.AddChild(torusNode);
            //Add the box node to the scene graph
            scene.RootNode.AddChild(boxRotationParentNode);
            boxRotationParentNode.AddChild(boxTransNode);
            boxTransNode.AddChild(boxControlPanel);
            boxControlPanel.AddChild(boxControlPanel1);
            boxControlPanel1.AddChild(boxControlPanel2);
            boxControlPanel2.AddChild(boxRotateSunNode);
            boxRotateSunNode.AddChild(boxNode);
        }

        private void CreateSolar2DGUI()
        {
            // Create the main panel which holds all other GUI components
            G2DPanel frame = new G2DPanel();
            frame.Bounds = new Rectangle(10, State.Height - 170, 90, 160);
            frame.Border = GoblinEnums.BorderFactory.LineBorder;
            frame.BorderColor = Color.Gold;
            // Ranges from 0 (fully transparent) to 1 (fully opaque)
            frame.Transparency = 0.2f;
            //Label for the panel.
            G2DLabel label1 = new G2DLabel("Camera Control");
            label1.TextFont = textFont2;
            label1.Bounds = new Rectangle(5, 2, 80, 15);
            //Label for the first slider.
            G2DLabel label2 = new G2DLabel("-4    x-axis    4");
            label2.TextFont = textFont1;
            label2.Bounds = new Rectangle(5, 15, 80, 15);
            // Create a slider (moving camera along x axis).
            G2DSlider slider1 = new G2DSlider();
            slider1.TextFont = textFont1;
            slider1.Bounds = new Rectangle(5, 40, 80, 15);
            slider1.Maximum = 4;
            slider1.Minimum = -4;
            slider1.MajorTickSpacing = 0;
            slider1.MinorTickSpacing = 1;
            slider1.Value = 0;
            slider1.PaintTicks = true;
            slider1.PaintLabels = true;
            slider1.StateChangedEvent += new StateChanged(HandleStateChanged1);
            //Label for the second slider
            G2DLabel label3 = new G2DLabel("-4    y-axis    4");
            label3.TextFont = textFont1;
            label3.Bounds = new Rectangle(5, 65, 80, 15);
            // Create a slider (moving camera along y axis).
            G2DSlider slider2 = new G2DSlider();
            slider2.TextFont = textFont1;
            slider2.Bounds = new Rectangle(5, 90, 80, 15);
            slider2.Maximum = 4;
            slider2.Minimum = -4;
            slider2.MajorTickSpacing = 0;
            slider2.MinorTickSpacing = 1;
            slider2.Value = 0;
            slider2.PaintTicks = true;
            slider2.PaintLabels = true;
            slider2.StateChangedEvent += new StateChanged(HandleStateChanged2);
            //Label for the third slider.
            G2DLabel label4 = new G2DLabel("-4    z-axis    4");
            label4.TextFont = textFont1;
            label4.Bounds = new Rectangle(5, 115, 80, 15);
            // Create a slider (moving camera along z axis).
            G2DSlider slider3 = new G2DSlider();
            slider3.TextFont = textFont1;
            slider3.Bounds = new Rectangle(5, 140, 80, 15);
            slider3.Maximum = 4;
            slider3.Minimum = -4;
            slider3.MajorTickSpacing = 0;
            slider3.MinorTickSpacing = 1;
            slider3.Value = 0;
            slider3.PaintTicks = true;
            slider3.PaintLabels = true;
            slider3.StateChangedEvent += new StateChanged(HandleStateChanged3);
            //Add labels and sliders to the frame
            frame.AddChild(label1);
            frame.AddChild(label2);
            frame.AddChild(label3);
            frame.AddChild(label4);
            frame.AddChild(slider1);
            frame.AddChild(slider2);
            frame.AddChild(slider3);
            //Render the frame and add the frame to the scene.
            scene.UIRenderer.Add2DComponent(frame);
        }
        //State change handler function for the first slider.
        private void HandleStateChanged1(object source)
        {
            G2DComponent comp = (G2DComponent)source;
            //Set the cameraX value to the slider value.
            cameraX = ((G2DSlider)comp).Value;
        }
        //State change handler function for the second slider.
        private void HandleStateChanged2(object source)
        {
            G2DComponent comp = (G2DComponent)source;
            //Set the cameraY value to the slider value.
            cameraY = ((G2DSlider)comp).Value;
        }
        //State change handler function for the third slider.
        private void HandleStateChanged3(object source)
        {
            G2DComponent comp = (G2DComponent)source;
            //Set the cameraZ value to the slider value.
            cameraZ = ((G2DSlider)comp).Value;
        }

        private void CreatePlanet2DGUI()
        {
            planetFrame = new G2DPanel();
            planetFrame.Bounds = new Rectangle(670, State.Height - 200, 120, 190);
            planetFrame.Border = GoblinEnums.BorderFactory.LineBorder;
            planetFrame.BorderColor = Color.Gold;
            // Ranges from 0 (fully transparent) to 1 (fully opaque)
            planetFrame.Transparency = 0.5f;
            //Label for rotation
            G2DLabel label1 = new G2DLabel("Planet Rotates along:");
            label1.TextFont = textFont2;
            label1.Bounds = new Rectangle(5, 5, 80, 20);
            // Create radio button for x-axis rotation.
            G2DRadioButton radioX = new G2DRadioButton("x-axis");
            radioX.TextFont = textFont2;
            radioX.Bounds = new Rectangle(5, 15, 80, 20);
            radioX.ActionPerformedEvent += new ActionPerformed(HandleActionPerformedAxisX);
            // Create radio button for y-axis rotation.
            G2DRadioButton radioY = new G2DRadioButton("y-axis");
            radioY.TextFont = textFont2;
            radioY.Bounds = new Rectangle(5, 30, 80, 20);
            radioY.ActionPerformedEvent += new ActionPerformed(HandleActionPerformedAxisY);
            // Create radio button for z-axis rotation.
            G2DRadioButton radioZ = new G2DRadioButton("z-axis");
            radioZ.TextFont = textFont2;
            radioZ.Bounds = new Rectangle(5, 45, 80, 20);
            radioZ.ActionPerformedEvent += new ActionPerformed(HandleActionPerformedAxisZ);
            //Create a ButtonGroup object which controls the radio button selections
            group1 = new ButtonGroup();
            group1.Add(radioX);
            group1.Add(radioY);
            group1.Add(radioZ);
            //Label for rotation direction.
            G2DLabel label2 = new G2DLabel("Rotation Direction:");
            label2.TextFont = textFont2;
            label2.Bounds = new Rectangle(5, 65, 80, 20);
            // Create radio button for clockwise
            G2DRadioButton clockwise = new G2DRadioButton("Clockwise");
            clockwise.TextFont = textFont2;
            clockwise.Bounds = new Rectangle(5, 80, 80, 20);
            clockwise.ActionPerformedEvent += new ActionPerformed(HandleActionPerformedDirection);
            // Create radio button for counterclockwise.
            G2DRadioButton counterclockwise = new G2DRadioButton("Counterclockwise");
            counterclockwise.TextFont = textFont2;
            counterclockwise.Bounds = new Rectangle(5, 95, 80, 20);
            counterclockwise.ActionPerformedEvent += new ActionPerformed(HandleActionPerformedDirection);
            //Create a ButtonGroup object which controls the radio button selections.
            group2 = new ButtonGroup();
            group2.Add(clockwise);
            group2.Add(counterclockwise);
            //Label for speed
            G2DLabel label3 = new G2DLabel("Rotation Speed:");
            label3.TextFont = textFont2;
            label3.Bounds = new Rectangle(5, 115, 80, 20);
            //Slider for speed of rotation
            slider = new G2DSlider();
            slider.TextFont = textFont1;
            slider.Bounds = new Rectangle(5, 145, 110, 20);
            slider.Maximum = 8;
            slider.Minimum = 0;
            slider.MajorTickSpacing = 0;
            slider.MinorTickSpacing = 1;
            slider.Value = 0;
            slider.PaintTicks = true;
            slider.PaintLabels = true;
            slider.StateChangedEvent += new StateChanged(HandleStateChangedSpeed);
            G2DButton reset = new G2DButton("Reset");
            reset.Bounds = new Rectangle(5, 165, 55, 20);
            reset.TextFont = textFont;
            reset.ActionPerformedEvent += new ActionPerformed(HandleActionReset);
            G2DButton quit = new G2DButton("Quit");
            quit.Bounds = new Rectangle(65, 165, 50, 20);
            quit.ActionPerformedEvent += new ActionPerformed(HandleActionQuit);
            quit.TextFont = textFont;
            planetFrame.AddChild(label1);
            planetFrame.AddChild(radioX);
            planetFrame.AddChild(radioY);
            planetFrame.AddChild(radioZ);
            planetFrame.AddChild(label2);
            planetFrame.AddChild(clockwise);
            planetFrame.AddChild(counterclockwise);
            planetFrame.AddChild(label3);
            planetFrame.AddChild(slider);
            planetFrame.AddChild(reset);
            planetFrame.AddChild(quit);
            scene.UIRenderer.Add2DComponent(planetFrame);
        }
        private void CreateDubris2DGUI()
        {
            dubrisFrame = new G2DPanel();
            dubrisFrame.Bounds = new Rectangle(670, State.Height - 220, 120, 210);
            dubrisFrame.Border = GoblinEnums.BorderFactory.LineBorder;
            dubrisFrame.BorderColor = Color.Gold;
            // Ranges from 0 (fully transparent) to 1 (fully opaque)
            dubrisFrame.Transparency = 0.5f;
            //Label for rotation
            G2DLabel label1 = new G2DLabel("Debris Rotates along:");
            label1.TextFont = textFont2;
            label1.Bounds = new Rectangle(5, 5, 80, 20);
            // Create radio button for x-axis rotation.
            G2DRadioButton radioX = new G2DRadioButton("x-axis");
            radioX.TextFont = textFont2;
            radioX.Bounds = new Rectangle(5, 15, 80, 20);
            radioX.ActionPerformedEvent += new ActionPerformed(HandleActionPerformedAxisX);
            // Create radio button for y-axis rotation.
            G2DRadioButton radioY = new G2DRadioButton("y-axis");
            radioY.TextFont = textFont2;
            radioY.Bounds = new Rectangle(5, 30, 80, 20);
            radioY.ActionPerformedEvent += new ActionPerformed(HandleActionPerformedAxisY);
            // Create radio button for z-axis rotation.
            G2DRadioButton radioZ = new G2DRadioButton("z-axis");
            radioZ.TextFont = textFont2;
            radioZ.Bounds = new Rectangle(5, 45, 80, 20);
            radioZ.ActionPerformedEvent += new ActionPerformed(HandleActionPerformedAxisZ);
            //Create a ButtonGroup object which controls the radio button selections
            group1 = new ButtonGroup();
            group1.Add(radioX);
            group1.Add(radioY);
            group1.Add(radioZ);
            //Label for rotation direction.
            G2DLabel label2 = new G2DLabel("Rotation Direction:");
            label2.TextFont = textFont2;
            label2.Bounds = new Rectangle(5, 65, 80, 20);
            // Create radio button for clockwise
            G2DRadioButton clockwise = new G2DRadioButton("Clockwise");
            clockwise.TextFont = textFont2;
            clockwise.Bounds = new Rectangle(5, 80, 80, 20);
            clockwise.ActionPerformedEvent += new ActionPerformed(HandleActionPerformedDirection);
            // Create radio button for counterclockwise.
            G2DRadioButton counterclockwise = new G2DRadioButton("Counterclockwise");
            counterclockwise.TextFont = textFont2;
            counterclockwise.Bounds = new Rectangle(5, 95, 80, 20);
            counterclockwise.ActionPerformedEvent += new ActionPerformed(HandleActionPerformedDirection);
            //Create a ButtonGroup object which controls the radio button selections.
            group2 = new ButtonGroup();
            group2.Add(clockwise);
            group2.Add(counterclockwise);
            //Label for speed
            G2DLabel label3 = new G2DLabel("Rotation Speed:");
            label3.TextFont = textFont2;
            label3.Bounds = new Rectangle(5, 115, 80, 20);
            //Slider for speed of rotation
            slider1 = new G2DSlider();
            slider1.TextFont = textFont1;
            slider1.Bounds = new Rectangle(5, 145, 110, 20);
            slider1.Maximum = 8;
            slider1.Minimum = 0;
            slider1.MajorTickSpacing = 0;
            slider1.MinorTickSpacing = 1;
            slider1.Value = 0;
            slider1.PaintTicks = true;
            slider1.PaintLabels = true;
            slider1.StateChangedEvent += new StateChanged(HandleStateChangedSpeed);
            G2DButton escape = new G2DButton("Escape Solar System");
            escape.Bounds = new Rectangle(1, 165, 117, 20);
            escape.TextFont = textFont4;
            escape.ActionPerformedEvent += new ActionPerformed(HandleActionEscape);
            G2DButton reset = new G2DButton("Reset");
            reset.Bounds = new Rectangle(5, 185, 55, 20);
            reset.TextFont = textFont;
            reset.ActionPerformedEvent += new ActionPerformed(HandleActionReset);
            G2DButton quit = new G2DButton("Quit");
            quit.Bounds = new Rectangle(65, 185, 50, 20);
            quit.ActionPerformedEvent += new ActionPerformed(HandleActionQuit);
            quit.TextFont = textFont;
            dubrisFrame.AddChild(label1);
            dubrisFrame.AddChild(radioX);
            dubrisFrame.AddChild(radioY);
            dubrisFrame.AddChild(radioZ);
            dubrisFrame.AddChild(label2);
            dubrisFrame.AddChild(clockwise);
            dubrisFrame.AddChild(counterclockwise);
            dubrisFrame.AddChild(label3);
            dubrisFrame.AddChild(slider1);
            dubrisFrame.AddChild(escape);
            dubrisFrame.AddChild(reset);
            dubrisFrame.AddChild(quit);
            scene.UIRenderer.Add2DComponent(dubrisFrame);
        }
        //State change handler function for rotation axis.
        private void HandleActionPerformedAxisX(object source)
        {
            G2DComponent comp = (G2DComponent)source;
            rotationAxis = ((G2DRadioButton)comp).Text;
            slider.Value = (int) valueX;
            slider1.Value = (int) valueX;
        }
        //State change handler function for rotation axis.
        private void HandleActionPerformedAxisY(object source)
        {
            G2DComponent comp = (G2DComponent)source;
            rotationAxis = ((G2DRadioButton)comp).Text;
            slider.Value = (int)valueY;
            slider1.Value = (int)valueY;
        }
        //State change handler function for rotation axis.
        private void HandleActionPerformedAxisZ(object source)
        {
            G2DComponent comp = (G2DComponent)source;
            rotationAxis = ((G2DRadioButton)comp).Text;
            slider.Value = (int)valueZ;
            slider1.Value = (int)valueZ;
        }
        //State change handler function for rotation direction.
        private void HandleActionPerformedDirection(object source)
        {
            G2DComponent comp = (G2DComponent)source;
            rotationDirection = ((G2DRadioButton)comp).Text;
        }       
        //State change handler function for speed control.
        private void HandleStateChangedSpeed(object source)
        {
            G2DComponent comp = (G2DComponent)source;
            rotationSpeed = ((G2DSlider)comp).Value;
        }
        private void HandleActionReset(object source)
        {
            valueX = 0;
            valueY = 0;
            valueZ = 0;
            slider1.Value = 0;
            slider.Value = 0;
            rotationSpeed = 0;
            dubrisEscape = false;

            earthControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, 0);
            earthControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
            earthControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, 0);
            moonControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, 0);
            moonControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
            moonControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, 0);
            mercuryControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, 0);
            mercuryControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
            mercuryControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, 0);
            marsControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, 0);
            marsControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
            marsControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, 0);
            jupiterControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, 0);
            jupiterControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
            jupiterControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, 0);
            coneControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, 0);
            coneControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
            coneControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, 0);
            coneControlPanel.Translation = Vector3.Zero;
            cylinderControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, 0);
            cylinderControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
            cylinderControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, 0);
            cylinderControlPanel.Translation = Vector3.Zero;
            boxControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, 0);
            boxControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
            boxControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, 0);
            boxControlPanel.Translation = Vector3.Zero;
            torusControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, 0);
            torusControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
            torusControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, 0);
            torusControlPanel.Translation = Vector3.Zero;

            earthRotateX = false;
            moonRotateX = false;
            mercuryRotateX = false;
            marsRotateX = false;
            jupiterRotateX = false;
            cylinderRotateX = false;
            coneRotateX = false;
            boxRotateX = false; 
            torusRotateX = false;
            earthRotateY = false;
            moonRotateY = false;
            mercuryRotateY = false;
            marsRotateY = false;
            jupiterRotateY = false;
            cylinderRotateY = false;
            coneRotateY = false;
            boxRotateY = false;
            torusRotateY = false;
            earthRotateZ = false;
            moonRotateZ = false;
            mercuryRotateZ = false;
            marsRotateZ = false;
            jupiterRotateZ = false;
            cylinderRotateZ = false;
            coneRotateZ = false;
            boxRotateZ = false;
            torusRotateZ = false;

            earthRotationSpeed1 = 0;
            moonRotationSpeed1 = 0;
            marsRotationSpeed1 = 0;
            jupiterRotationSpeed1 = 0;
            mercuryRotationSpeed1 = 0;
            cylinderRotationSpeed1 = 0;
            coneRotationSpeed1 = 0;
            torusRotationSpeed1 = 0;
            boxRotationSpeed1 = 0;
            earthRotationSpeed2 = 0;
            moonRotationSpeed2 = 0;
            marsRotationSpeed2 = 0;
            jupiterRotationSpeed2 = 0;
            mercuryRotationSpeed2 = 0;
            cylinderRotationSpeed2 = 0;
            coneRotationSpeed2 = 0;
            torusRotationSpeed2 = 0;
            boxRotationSpeed2 = 0;
            earthRotationSpeed3 = 0;
            moonRotationSpeed3 = 0;
            marsRotationSpeed3 = 0;
            jupiterRotationSpeed3 = 0;
            mercuryRotationSpeed3 = 0;
            cylinderRotationSpeed3 = 0;
            coneRotationSpeed3 = 0;
            torusRotationSpeed3 = 0;
            boxRotationSpeed3 = 0;
        }

        private void HandleActionEscape(object source)
        {
            dubrisEscape = true;
        }
        private void HandleActionQuit(object source)
        {
            MouseInput.Instance.MouseClickEvent += new HandleMouseClick(MouseClickHandler);
            label = "Nothing is selected";
            rotationSpeed = 0;
            dubrisEscape = false;
            planetFrame.Visible = false;
            dubrisFrame.Visible = false;
            valueX = 0;
            valueY = 0;
            valueZ = 0;
            slider.Value = 0;
            slider1.Value = 0;

            earthRotationSpeed1 = 0;
            moonRotationSpeed1 = 0;
            marsRotationSpeed1 = 0;
            jupiterRotationSpeed1 = 0;
            mercuryRotationSpeed1 = 0;
            cylinderRotationSpeed1 = 0;
            coneRotationSpeed1 = 0;
            torusRotationSpeed1 = 0;
            boxRotationSpeed1 = 0;
            earthRotationSpeed2 = 0;
            moonRotationSpeed2 = 0;
            marsRotationSpeed2 = 0;
            jupiterRotationSpeed2 = 0;
            mercuryRotationSpeed2 = 0;
            cylinderRotationSpeed2 = 0;
            coneRotationSpeed2 = 0;
            torusRotationSpeed2 = 0;
            boxRotationSpeed2 = 0;
            earthRotationSpeed3 = 0;
            moonRotationSpeed3 = 0;
            marsRotationSpeed3 = 0;
            jupiterRotationSpeed3 = 0;
            mercuryRotationSpeed3 = 0;
            cylinderRotationSpeed3 = 0;
            coneRotationSpeed3 = 0;
            torusRotationSpeed3 = 0;
            boxRotationSpeed3 = 0;
        }
        private void MouseClickHandler(int button, Point mouseLocation)
        {
            // Only perform the ray picking if the clicked button is LeftButton
            if (button == MouseInput.LeftButton)
            {
                //0 means on the near clipping plane, and 1 means on the far clipping plane
                Vector3 nearSource = new Vector3(mouseLocation.X, mouseLocation.Y, 0);
                Vector3 farSource = new Vector3(mouseLocation.X, mouseLocation.Y, 1);
                //Now convert the near and far source to actual near and far 3D points based on our eye location and view frustum
                Vector3 nearPoint = graphics.GraphicsDevice.Viewport.Unproject(nearSource, State.ProjectionMatrix, State.ViewMatrix, Matrix.Identity);
                Vector3 farPoint = graphics.GraphicsDevice.Viewport.Unproject(farSource, State.ProjectionMatrix, State.ViewMatrix, Matrix.Identity);
                //Have the physics engine intersect the pick ray defined by the nearPoint and farPoint with the physics objects in the scene (which we have set up to approximate the model geometry).
                List<PickedObject> pickedObjects = ((NewtonPhysics)scene.PhysicsEngine).PickRayCast(nearPoint, farPoint);
                //If one or more objects intersect with our ray vector
                if (pickedObjects.Count > 0)
                {
                    //Since PickedObject can be compared (which means it implements IComparable), we can sort it in the order of closest intersected object to farthest intersected object
                    pickedObjects.Sort();
                    //We only care about the closest picked object for now, so we'll simply display the name of the closest picked object whose container is a geometry node
                    label = ((GeometryNode)pickedObjects[0].PickedPhysicsObject.Container).Name + " is picked";
                }
                else
                    label = "Nothing is selected";
            }
        }

        void KeyPressHandler(Keys key, KeyModifier modifier)
        {
            //Move the camera up when press the "Up" key.
            if (key == Keys.Up)
                cameraY += (float)0.05;
            //Move the camera down when press the "Down" key.
            if (key == Keys.Down)
                cameraY -= (float)0.05;
            //Move the camera left when press the "Left" key.
            if (key == Keys.Left)
                cameraX -= (float)0.05;
            //Move the camera right when press the "Right" key.
            if (key == Keys.Right)
                cameraX += (float)0.05;
            //Move the camera in when press the "I" key.
            if (key == Keys.I)
                cameraZ -= (float)0.05;
            //Move the camera out when press the "O" key.
            if (key == Keys.O)
                cameraZ += (float)0.05;
            //Increase the field of view when press the "A" key.
            if (key == Keys.A)
            {
                cameraFieldY += 1;
            }
            //Decrease the field of view when press the "S" key.
            if (key == Keys.S)
            {
                cameraFieldY -= 1;
            }
            // Return to the initial view of the solar system
            if (key == Keys.R)
            {
                // Initialize flag to 0. Turn off all transformations and rotations that applied to the camera.
                flag = 0;
                // Initialize camera nodes rotations and tranformations to default value.
                myCameraNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode.Translation = Vector3.Zero;
                myCameraNode1.Translation = Vector3.Zero;
                myCameraNode2.Translation = Vector3.Zero;
                cameraX = 0;
                cameraY = 0;
                cameraZ = 0;
                cameraFieldY = 60;
                cameraNode.Camera.View = Matrix.CreateLookAt(new Vector3(0, 0, 5), Vector3.Zero, Vector3.Up);

                slider.Value = 0;
                rotationSpeed = 0;
                dubrisEscape = false;

                earthControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, 0);
                earthControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                earthControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, 0);
                moonControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, 0);
                moonControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                moonControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, 0);
                mercuryControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, 0);
                mercuryControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                mercuryControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, 0);
                marsControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, 0);
                marsControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                marsControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, 0);
                jupiterControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, 0);
                jupiterControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                jupiterControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, 0);
                coneControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, 0);
                coneControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                coneControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, 0);
                coneControlPanel.Translation = Vector3.Zero;
                cylinderControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, 0);
                cylinderControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                cylinderControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, 0);
                cylinderControlPanel.Translation = Vector3.Zero;
                boxControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, 0);
                boxControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                boxControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, 0);
                boxControlPanel.Translation = Vector3.Zero;
                torusControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, 0);
                torusControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                torusControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, 0);
                torusControlPanel.Translation = Vector3.Zero;

                earthRotateX = false;
                moonRotateX = false;
                mercuryRotateX = false;
                marsRotateX = false;
                jupiterRotateX = false;
                cylinderRotateX = false;
                coneRotateX = false;
                boxRotateX = false;
                torusRotateX = false;
                earthRotateY = false;
                moonRotateY = false;
                mercuryRotateY = false;
                marsRotateY = false;
                jupiterRotateY = false;
                cylinderRotateY = false;
                coneRotateY = false;
                boxRotateY = false;
                torusRotateY = false;
                earthRotateZ = false;
                moonRotateZ = false;
                mercuryRotateZ = false;
                marsRotateZ = false;
                jupiterRotateZ = false;
                cylinderRotateZ = false;
                coneRotateZ = false;
                boxRotateZ = false;
                torusRotateZ = false;
                valueX = 0;
                valueY = 0;
                valueZ = 0;

                earthRotationSpeed1 = 0;
                moonRotationSpeed1 = 0;
                marsRotationSpeed1 = 0;
                jupiterRotationSpeed1 = 0;
                mercuryRotationSpeed1 = 0;
                cylinderRotationSpeed1 = 0;
                coneRotationSpeed1 = 0;
                torusRotationSpeed1 = 0;
                boxRotationSpeed1 = 0;
                earthRotationSpeed2 = 0;
                moonRotationSpeed2 = 0;
                marsRotationSpeed2 = 0;
                jupiterRotationSpeed2 = 0;
                mercuryRotationSpeed2 = 0;
                cylinderRotationSpeed2 = 0;
                coneRotationSpeed2 = 0;
                torusRotationSpeed2 = 0;
                boxRotationSpeed2 = 0;
                earthRotationSpeed3 = 0;
                moonRotationSpeed3 = 0;
                marsRotationSpeed3 = 0;
                jupiterRotationSpeed3 = 0;
                mercuryRotationSpeed3 = 0;
                cylinderRotationSpeed3 = 0;
                coneRotationSpeed3 = 0;
                torusRotationSpeed3 = 0;
                boxRotationSpeed3 = 0;
            }
            //Attach the camera to the Sun.
            if (key == Keys.D1)
            {
                // Initialize flag to 0. Turn off all transformations and rotations that applied to the camera.
                flag = 0;
                // Initialize camera nodes rotations and tranformations to default value.
                myCameraNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode.Translation = Vector3.Zero;
                myCameraNode1.Translation = Vector3.Zero;
                myCameraNode2.Translation = Vector3.Zero;
                cameraX = 0;
                cameraY = 0;
                cameraZ = 0;
                // Move the camera along z axis for 1.5 unit.
                cameraNode.Camera.View = Matrix.CreateLookAt(new Vector3(0, 0, (float)1.5), Vector3.Zero, Vector3.Up);
            }
            //Attach the camera to the Earth.
            if (key == Keys.D2)
            {
                // Initialize flag to 0. Turn off all transformations and rotations that applied to the camera.
                flag = 0;
                // Initialize camera nodes rotations and tranformations to default value.
                myCameraNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode.Translation = Vector3.Zero;
                myCameraNode1.Translation = Vector3.Zero;
                myCameraNode2.Translation = Vector3.Zero;
                cameraX = 0;
                cameraY = 0;
                cameraZ = 0;
                // Set the flag to 1: Turn on transformations and rotations for the Earth.
                flag = 1;
            }
            //Attach the camera to the Mercury
            if (key == Keys.D3)
            {
                // Initialize flag to 0. Turn off all transformations and rotations that applied to the camera.
                flag = 0;
                // Initialize camera nodes rotations and tranformations to default value.
                myCameraNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode.Translation = Vector3.Zero;
                myCameraNode1.Translation = Vector3.Zero;
                myCameraNode2.Translation = Vector3.Zero;
                cameraX = 0;
                cameraY = 0;
                cameraZ = 0;   
                // Set the flag to 2: Turn on transformations and rotations for the Mercury.
                flag = 2;
            }
            //Attach the camera to the Mars.
            if (key == Keys.D4)
            {
                // Initialize flag to 0. Turn off all transformations and rotations that applied to the camera.
                flag = 0;
                // Initialize camera nodes rotations and tranformations to default value.
                myCameraNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode.Translation = Vector3.Zero;
                myCameraNode1.Translation = Vector3.Zero;
                myCameraNode2.Translation = Vector3.Zero;
                cameraX = 0;
                cameraY = 0;
                cameraZ = 0;
                // Set the flag to 3: Turn on transformations and rotations for the Mars.
                flag = 3;
            }
            //Attach the camera to the Jupiter.
            if (key == Keys.D5)
            {
                // Initialize flag to 0. Turn off all transformations and rotations that applied to the camera.
                flag = 0;
                // Initialize camera nodes rotations and tranformations to default value.
                myCameraNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode.Translation = Vector3.Zero;
                myCameraNode1.Translation = Vector3.Zero;
                myCameraNode2.Translation = Vector3.Zero;
                cameraX = 0;
                cameraY = 0;
                cameraZ = 0;
                // Set the flag to 2: Turn on transformations and rotations for the Jupiter.
                flag = 4;
            }
            //Attach the camera to the Moon.
            if (key == Keys.D6)
            {
                // Initialize flag to 0. Turn off all transformations and rotations that applied to the camera.
                flag = 0;
                // Initialize camera nodes rotations and tranformations to default value.
                myCameraNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode.Translation = Vector3.Zero;
                myCameraNode1.Translation = Vector3.Zero;
                myCameraNode2.Translation = Vector3.Zero;
                cameraX = 0;
                cameraY = 0;
                cameraZ = 0;
                // Set the flag to 2: Turn on transformations and rotations for the Moon.
                flag = 5;
            }
            //Attach the camera to the cylinder.
            if (key == Keys.D7)
            {
                // Initialize flag to 0. Turn off all transformations and rotations that applied to the camera.
                flag = 0;
                // Initialize camera nodes rotations and tranformations to default value.
                myCameraNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode.Translation = Vector3.Zero;
                myCameraNode1.Translation = Vector3.Zero;
                myCameraNode2.Translation = Vector3.Zero;
                cameraX = 0;
                cameraY = 0;
                cameraZ = 0;
                // Set the flag to 2: Turn on transformations and rotations for the Moon.
                flag = 6;
            }
            //Attach the camera to the cone
            if (key == Keys.D8)
            {
                // Initialize flag to 0. Turn off all transformations and rotations that applied to the camera.
                flag = 0;
                // Initialize camera nodes rotations and tranformations to default value.
                myCameraNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode.Translation = Vector3.Zero;
                myCameraNode1.Translation = Vector3.Zero;
                myCameraNode2.Translation = Vector3.Zero;
                cameraX = 0;
                cameraY = 0;
                cameraZ = 0;
                // Set the flag to 2: Turn on transformations and rotations for the Moon.
                flag = 7;
            }
            //Attach the camera to the torus.
            if (key == Keys.D9)
            {
                // Initialize flag to 0. Turn off all transformations and rotations that applied to the camera.
                flag = 0;
                // Initialize camera nodes rotations and tranformations to default value.
                myCameraNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode.Translation = Vector3.Zero;
                myCameraNode1.Translation = Vector3.Zero;
                myCameraNode2.Translation = Vector3.Zero;
                cameraX = 0;
                cameraY = 0;
                cameraZ = 0;
                // Set the flag to 2: Turn on transformations and rotations for the Moon.
                flag = 8;
            }
            //Attach the camera to the box.
            if (key == Keys.D0)
            {
                // Initialize flag to 0. Turn off all transformations and rotations that applied to the camera.
                flag = 0;
                // Initialize camera nodes rotations and tranformations to default value.
                myCameraNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0);
                myCameraNode.Translation = Vector3.Zero;
                myCameraNode1.Translation = Vector3.Zero;
                myCameraNode2.Translation = Vector3.Zero;
                cameraX = 0;
                cameraY = 0;
                cameraZ = 0;
                // Set the flag to 2: Turn on transformations and rotations for the Moon.
                flag = 9;
            }
            if (key == Keys.Escape)
            {
                MouseInput.Instance.MouseClickEvent += new HandleMouseClick(MouseClickHandler);
                label = "Nothing is selected";
                rotationSpeed = 0;
                dubrisEscape = false;
                planetFrame.Visible = false;
                dubrisFrame.Visible = false;
                valueX = 0;
                valueY = 0;
                valueZ = 0;
                slider.Value = 0;
                slider1.Value = 0;
                rotationSpeed = 0;

                earthRotationSpeed1 = 0;
                moonRotationSpeed1 = 0;
                marsRotationSpeed1 = 0;
                jupiterRotationSpeed1 = 0;
                mercuryRotationSpeed1 = 0;
                cylinderRotationSpeed1 = 0;
                coneRotationSpeed1 = 0;
                torusRotationSpeed1 = 0;
                boxRotationSpeed1 = 0;
                earthRotationSpeed2 = 0;
                moonRotationSpeed2 = 0;
                marsRotationSpeed2 = 0;
                jupiterRotationSpeed2 = 0;
                mercuryRotationSpeed2 = 0;
                cylinderRotationSpeed2 = 0;
                coneRotationSpeed2 = 0;
                torusRotationSpeed2 = 0;
                boxRotationSpeed2 = 0;
                earthRotationSpeed3 = 0;
                moonRotationSpeed3 = 0;
                marsRotationSpeed3 = 0;
                jupiterRotationSpeed3 = 0;
                mercuryRotationSpeed3 = 0;
                cylinderRotationSpeed3 = 0;
                coneRotationSpeed3 = 0;
                torusRotationSpeed3 = 0;
                boxRotationSpeed3 = 0;
            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            textFont = Content.Load<SpriteFont>("Arial");
            textFont1 = Content.Load<SpriteFont>("ArialSmall");
            textFont2 = Content.Load<SpriteFont>("ArialMiddle");
            textFont3 = Content.Load<SpriteFont>("ArialQuitMessage");
            textFont4 = Content.Load<SpriteFont>("ArialEscape");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            //base.Update(gameTime);
            if (label == "Sun is picked")
            {
                //Rotations for the Sun.
                mySunRotationAngle += (float)gameTime.ElapsedGameTime.TotalSeconds * (rotationRate - (float)0.6);
                mySunRotationParentNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, mySunRotationAngle);
                //Unable all bounding boxes excepted the target object.
                ((Model)myEarth.Model).ShowBoundingBox = false;
                ((Model)myMoon.Model).ShowBoundingBox = false;
                ((Model)myMars.Model).ShowBoundingBox = false;
                ((Model)myJupiter.Model).ShowBoundingBox = false;
                ((Model)myMercury.Model).ShowBoundingBox = false;
                coneNode.Model.ShowBoundingBox = false;
                torusNode.Model.ShowBoundingBox = false;
                cylinderNode.Model.ShowBoundingBox = false;
                boxNode.Model.ShowBoundingBox = false;
                //Show bounding box for the target object.
                ((Model)mySun.Model).ShowBoundingBox = true;
                //Hide planet control panel.
                planetFrame.Visible = false;
                //Hide dubris control panel.
                dubrisFrame.Visible = false;
            }
            else{
                //Rotations for the Sun.
                mySunRotationAngle += (float)gameTime.ElapsedGameTime.TotalSeconds * (rotationRate - (float) 0.6);
                mySunRotationParentNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, mySunRotationAngle);
                if (label != "Earth is picked")
                {
                    //Rotations for the Earth.
                    myEarthRotationAngle += (float)gameTime.ElapsedGameTime.TotalSeconds * rotationRate;
                    myEarthRotationParentNode1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myEarthRotationAngle);
                    myEarthRotationParentNode2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myEarthRotationAngle);
                    if (label != "Moon is picked")
                    {
                        //Rotations and transformations for the Moon.
                        myMoonRotationAngle += (float)gameTime.ElapsedGameTime.TotalSeconds * (rotationRate + (float)2);
                        myMoonRotationParentNode1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myEarthRotationAngle);
                        myMoonRotationParentNode2.Translation = new Vector3(0, 0, 2);
                        myMoonRotationParentNode3.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myMoonRotationAngle);
                        myMoonRotationParentNode4.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myMoonRotationAngle);

                        myMoonFreezeEarthRotationAngle = myEarthRotationAngle;
                    }
                }
                if (label != "Mercury is picked")
                {
                    //Rotations for the Mercury.
                    myMercuryRotationAngle += (float)gameTime.ElapsedGameTime.TotalSeconds * (rotationRate + (float)0.6);
                    myMercuryRotationParentNode1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myMercuryRotationAngle);
                    myMercuryRotationParentNode2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myMercuryRotationAngle);
                }
                if (label != "Mars is picked")
                {
                    //Rotations for the Mars.
                    myMarsRotationAngle += (float)gameTime.ElapsedGameTime.TotalSeconds * (rotationRate - (float)0.5);
                    myMarsRotationParentNode1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myMarsRotationAngle);
                    myMarsRotationParentNode2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myMarsRotationAngle);
                }
                if (label != "Jupiter is picked")
                {
                    //Rotations for the Jupiter.
                    myJupiterRotationAngle += (float)gameTime.ElapsedGameTime.TotalSeconds * (rotationRate - (float)0.7);
                    myJupiterRotationParentNode1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myJupiterRotationAngle);
                    myJupiterRotationParentNode2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myJupiterRotationAngle);
                }
                //Rotations for the cylinder.
                myCylinderRotatiionAngle += (float)gameTime.ElapsedGameTime.TotalSeconds * rotationRate;
                cylinderRotationParentNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myCylinderRotatiionAngle);
                //Rotations for the cone.
                myConeRotatiionAngle += (float)gameTime.ElapsedGameTime.TotalSeconds * (rotationRate + (float) 0.05);
                coneRotationParentNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myConeRotatiionAngle);
                //Rotations for the torus.
                myTorusRotatiionAngle += (float)gameTime.ElapsedGameTime.TotalSeconds * (rotationRate + (float)0.1);
                torusRotationParentNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myTorusRotatiionAngle);
                //Rotations for the box.
                myBoxRotatiionAngle += (float)gameTime.ElapsedGameTime.TotalSeconds * (rotationRate + (float)0.15);
                boxRotationParentNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myBoxRotatiionAngle);
            }
            /*
             * If and else if statements for camera rotations and transformation. The flag is to keep track the object
             * that the camera will be attached. The same rotations and transformation to the moving planets and objects
             * will be applied to the camera once the user press the associated key.
             */
            if (flag == 1)
            {
                //Rotations to attach the camera to the Earth.
                cameraNode.Camera.View = Matrix.CreateLookAt(new Vector3(cameraX, cameraY, (float)2.8 + cameraZ), Vector3.Zero, Vector3.Up);
                myCameraNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myEarthRotationAngle);
            }
            else if (flag == 2)
            {
                //Rotations to attach the camera to the Mercury.
                myCameraNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myMercuryRotationAngle);
                cameraNode.Camera.View = Matrix.CreateLookAt(new Vector3(cameraX, cameraY, (float)1.2 + cameraZ), Vector3.Zero, Vector3.Up);
            }
            else if (flag == 3)
            {
                //Rotations to attach the camera to the Mars.
                myCameraNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myMarsRotationAngle);
                cameraNode.Camera.View = Matrix.CreateLookAt(new Vector3(cameraX, cameraY, (float)3.3 + cameraZ), Vector3.Zero, Vector3.Up);
            }
            else if (flag == 4)
            {
                //Rotations to attach the camera to the Jupiter.
                myCameraNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myJupiterRotationAngle);
                cameraNode.Camera.View = Matrix.CreateLookAt(new Vector3(cameraX, cameraY, (float)4.8 + cameraZ), Vector3.Zero, Vector3.Up);
            }
            else if (flag == 5)
            {
                if (label == "Moon is picked")
                {
                    //Rotations and transformations to attach the camera to the Moon.
                    cameraNode.Camera.View = Matrix.CreateLookAt(new Vector3(cameraX, cameraY, (float)0.7 + cameraZ), Vector3.Zero, Vector3.Up);
                    myCameraNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myMoonFreezeEarthRotationAngle);
                    myCameraNode1.Translation = new Vector3(0, 0, 2);
                    myCameraNode2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myMoonRotationAngle);
                }
                else
                {
                    //Rotations and transformations to attach the camera to the Moon.
                    cameraNode.Camera.View = Matrix.CreateLookAt(new Vector3(cameraX, cameraY, (float)0.7 + cameraZ), Vector3.Zero, Vector3.Up);
                    myCameraNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myEarthRotationAngle);
                    myCameraNode1.Translation = new Vector3(0, 0, 2);
                    myCameraNode2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myMoonRotationAngle);
                }
            }
            else if (flag == 6)
            {
                //Rotations to attach the camera to the cylinder.
                cameraNode.Camera.View = Matrix.CreateLookAt(new Vector3(cameraX, (float)0.6 + cameraY, (float)3.5 + cameraZ), Vector3.Zero, Vector3.Up);
                myCameraNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myCylinderRotatiionAngle);
            }
            else if (flag == 7)
            {
                //Rotations to attach the camera to the cone.
                cameraNode.Camera.View = Matrix.CreateLookAt(new Vector3(cameraX, (float)0.4 + cameraY, (float)3.6 + cameraZ), Vector3.Zero, Vector3.Up);
                myCameraNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myConeRotatiionAngle);
            }
            else if (flag == 8)
            {
                //Rotations to attach the camera to the torus.
                cameraNode.Camera.View = Matrix.CreateLookAt(new Vector3(cameraX, (float)0.6 + cameraY, (float)3.8 + cameraZ), Vector3.Zero, Vector3.Up);
                myCameraNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myTorusRotatiionAngle);
            }
            else if (flag == 9)
            {
                //Rotations to attach the camera to the box.
                cameraNode.Camera.View = Matrix.CreateLookAt(new Vector3(cameraX, (float)0.45 + cameraY, (float)3.7 + cameraZ), Vector3.Zero, Vector3.Up);
                myCameraNode.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, myBoxRotatiionAngle);
            }
            else
            {
                //Default camera manipulation on x, y and z axis.
                myCameraNode.Translation = new Vector3(cameraX, cameraY, cameraZ);
            }
            cameraNode.Camera.FieldOfViewY = MathHelper.ToRadians(cameraFieldY);

            if (label == "Earth is picked")
            {
                //Unable all bounding boxes excepted the target object.
                ((Model)mySun.Model).ShowBoundingBox = false;
                ((Model)myMoon.Model).ShowBoundingBox = false;
                ((Model)myMars.Model).ShowBoundingBox = false;
                ((Model)myJupiter.Model).ShowBoundingBox = false;
                ((Model)myMercury.Model).ShowBoundingBox = false;
                coneNode.Model.ShowBoundingBox = false;
                torusNode.Model.ShowBoundingBox = false;
                cylinderNode.Model.ShowBoundingBox = false;
                boxNode.Model.ShowBoundingBox = false;
                ((Model)myEarth.Model).ShowBoundingBox = true;
                //Hide dubris control panel.
                dubrisFrame.Visible = false;
                //Display planet control panel.
                planetFrame.Visible = true;
                MouseInput.Instance.MouseClickEvent -= new HandleMouseClick(MouseClickHandler);
                UI2DRenderer.WriteText(new Vector2(540, 5), quitLabel, Color.Red, textFont3, Vector2.One * 0.5f);
                //Add panel controlled rotations.
                if (rotationDirection == "Clockwise")
                {
                    controlPanelEarthRateClockwiseX += (float)gameTime.ElapsedGameTime.TotalSeconds * earthRotationSpeed1;
                    controlPanelEarthRateClockwiseY += (float)gameTime.ElapsedGameTime.TotalSeconds * earthRotationSpeed2;
                    controlPanelEarthRateClockwiseZ += (float)gameTime.ElapsedGameTime.TotalSeconds * earthRotationSpeed3;
                }
                if (rotationDirection == "Counterclockwise")
                {
                    controlPanelEarthRateCounterclockwiseX -= (float)gameTime.ElapsedGameTime.TotalSeconds * earthRotationSpeed1;
                    controlPanelEarthRateCounterclockwiseY -= (float)gameTime.ElapsedGameTime.TotalSeconds * earthRotationSpeed2;
                    controlPanelEarthRateCounterclockwiseZ -= (float)gameTime.ElapsedGameTime.TotalSeconds * earthRotationSpeed3;
                }

                if (rotationAxis == "x-axis" || earthRotateX == true)
                {
                    if (rotationAxis == "x-axis")
                    {
                        earthRotationSpeed1 = rotationSpeed;
                        valueX = earthRotationSpeed1;
                    }
                    earthControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, controlPanelEarthRateClockwiseX + controlPanelEarthRateCounterclockwiseX);
                    earthRotateX = true;
                }
                if (rotationAxis == "y-axis" || earthRotateY == true)
                {
                    if (rotationAxis == "y-axis")
                    {
                        earthRotationSpeed2 = rotationSpeed;
                        valueY = earthRotationSpeed2;
                    }
                    earthControlPanel1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, controlPanelEarthRateClockwiseY + controlPanelEarthRateCounterclockwiseY);
                    earthRotateY = true;
                }
                if (rotationAxis == "z-axis" || earthRotateZ == true)
                {
                    if (rotationAxis == "z-axis")
                    {
                        earthRotationSpeed3 = rotationSpeed;
                        valueZ = earthRotationSpeed3;
                    }
                    earthControlPanel2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, controlPanelEarthRateClockwiseZ + controlPanelEarthRateCounterclockwiseZ);
                    earthRotateZ = true;
                }
            }
            if (label == "Moon is picked")
            {
                //Unable all bounding boxes excepted the target object.
                ((Model)mySun.Model).ShowBoundingBox = false;
                ((Model)myEarth.Model).ShowBoundingBox = false;
                ((Model)myMars.Model).ShowBoundingBox = false;
                ((Model)myJupiter.Model).ShowBoundingBox = false;
                ((Model)myMercury.Model).ShowBoundingBox = false;
                coneNode.Model.ShowBoundingBox = false;
                torusNode.Model.ShowBoundingBox = false;
                cylinderNode.Model.ShowBoundingBox = false;
                boxNode.Model.ShowBoundingBox = false;
                //Show bounding box for the target object.
                ((Model)myMoon.Model).ShowBoundingBox = true;
                //Hide dubris control panel.
                dubrisFrame.Visible = false;
                //Display planet control panel.
                planetFrame.Visible = true;
                MouseInput.Instance.MouseClickEvent -= new HandleMouseClick(MouseClickHandler);
                UI2DRenderer.WriteText(new Vector2(540, 5), quitLabel, Color.Red, textFont3, Vector2.One * 0.5f);
                //Add panel controlled rotations.
                if (rotationDirection == "Clockwise")
                {
                    controlPanelMoonRateClockwiseX += (float)gameTime.ElapsedGameTime.TotalSeconds * moonRotationSpeed1;
                    controlPanelMoonRateClockwiseY += (float)gameTime.ElapsedGameTime.TotalSeconds * moonRotationSpeed2;
                    controlPanelMoonRateClockwiseZ += (float)gameTime.ElapsedGameTime.TotalSeconds * moonRotationSpeed3;
                }
                if (rotationDirection == "Counterclockwise")
                {
                    controlPanelMoonRateCounterclockwiseX -= (float)gameTime.ElapsedGameTime.TotalSeconds * moonRotationSpeed1;
                    controlPanelMoonRateCounterclockwiseY -= (float)gameTime.ElapsedGameTime.TotalSeconds * moonRotationSpeed2;
                    controlPanelMoonRateCounterclockwiseZ -= (float)gameTime.ElapsedGameTime.TotalSeconds * moonRotationSpeed3;
                }

                if (rotationAxis == "x-axis" || moonRotateX == true)
                {
                    if (rotationAxis == "x-axis")
                    {
                        moonRotationSpeed1 = rotationSpeed;
                        valueX = moonRotationSpeed1;
                    }
                    moonControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, controlPanelMoonRateClockwiseX + controlPanelMoonRateCounterclockwiseX);
                    moonRotateX = true;
                }
                if (rotationAxis == "y-axis" || moonRotateY == true)
                {
                    if (rotationAxis == "y-axis")
                    {
                        moonRotationSpeed2 = rotationSpeed;
                        valueY = moonRotationSpeed2;
                    }
                    moonControlPanel1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, controlPanelMoonRateClockwiseY + controlPanelMoonRateCounterclockwiseY);
                    moonRotateY = true;
                }
                if (rotationAxis == "z-axis" || moonRotateZ == true)
                {
                    if (rotationAxis == "z-axis")
                    {
                        moonRotationSpeed3 = rotationSpeed;
                        valueZ = moonRotationSpeed3;
                    }
                    moonControlPanel2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, controlPanelMoonRateClockwiseZ + controlPanelMoonRateCounterclockwiseZ);
                    moonRotateZ = true;
                }
            }
            if (label == "Mars is picked")
            {
                //Unable all bounding boxes excepted the target object.
                ((Model)mySun.Model).ShowBoundingBox = false;
                ((Model)myEarth.Model).ShowBoundingBox = false;
                ((Model)myMoon.Model).ShowBoundingBox = false;
                ((Model)myJupiter.Model).ShowBoundingBox = false;
                ((Model)myMercury.Model).ShowBoundingBox = false;
                coneNode.Model.ShowBoundingBox = false;
                torusNode.Model.ShowBoundingBox = false;
                cylinderNode.Model.ShowBoundingBox = false;
                boxNode.Model.ShowBoundingBox = false;
                //Show bounding box for the target object.
                ((Model)myMars.Model).ShowBoundingBox = true;
                //Hide dubris control panel.
                dubrisFrame.Visible = false;
                //Display planet control panel.
                planetFrame.Visible = true;
                MouseInput.Instance.MouseClickEvent -= new HandleMouseClick(MouseClickHandler);
                UI2DRenderer.WriteText(new Vector2(540, 5), quitLabel, Color.Red, textFont3, Vector2.One * 0.5f);
                //Add panel controlled rotations.
                if (rotationDirection == "Clockwise")
                {
                    controlPanelMarsRateClockwiseX += (float)gameTime.ElapsedGameTime.TotalSeconds * marsRotationSpeed1;
                    controlPanelMarsRateClockwiseY += (float)gameTime.ElapsedGameTime.TotalSeconds * marsRotationSpeed2;
                    controlPanelMarsRateClockwiseZ += (float)gameTime.ElapsedGameTime.TotalSeconds * marsRotationSpeed3;
                }
                if (rotationDirection == "Counterclockwise")
                {
                    controlPanelMarsRateCounterclockwiseX -= (float)gameTime.ElapsedGameTime.TotalSeconds * marsRotationSpeed1;
                    controlPanelMarsRateCounterclockwiseY -= (float)gameTime.ElapsedGameTime.TotalSeconds * marsRotationSpeed2;
                    controlPanelMarsRateCounterclockwiseZ -= (float)gameTime.ElapsedGameTime.TotalSeconds * marsRotationSpeed3;
                }

                if (rotationAxis == "x-axis" || marsRotateX == true)
                {
                    if (rotationAxis == "x-axis")
                    {
                        marsRotationSpeed1 = rotationSpeed;
                        valueX = marsRotationSpeed1;
                    }
                    marsControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, controlPanelMarsRateClockwiseX + controlPanelMarsRateCounterclockwiseX);
                    marsRotateX = true;
                }
                if (rotationAxis == "y-axis" || marsRotateY == true)
                {
                    if (rotationAxis == "y-axis")
                    {
                        marsRotationSpeed2 = rotationSpeed;
                        valueY = marsRotationSpeed2;
                    }
                    marsControlPanel1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, controlPanelMarsRateClockwiseY + controlPanelMarsRateCounterclockwiseY);
                    marsRotateY = true;
                }
                if (rotationAxis == "z-axis" || marsRotateZ == true)
                {
                    if (rotationAxis == "z-axis")
                    {
                        marsRotationSpeed3 = rotationSpeed;
                        valueZ = marsRotationSpeed3;
                    }
                    marsControlPanel2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, controlPanelMarsRateClockwiseZ + controlPanelMarsRateCounterclockwiseZ);
                    marsRotateZ = true;
                }
            }
            if (label == "Jupiter is picked")
            {
                //Unable all bounding boxes excepted the target object.
                ((Model)mySun.Model).ShowBoundingBox = false;
                ((Model)myEarth.Model).ShowBoundingBox = false;
                ((Model)myMoon.Model).ShowBoundingBox = false;
                ((Model)myMars.Model).ShowBoundingBox = false;
                ((Model)myMercury.Model).ShowBoundingBox = false;
                coneNode.Model.ShowBoundingBox = false;
                torusNode.Model.ShowBoundingBox = false;
                cylinderNode.Model.ShowBoundingBox = false;
                boxNode.Model.ShowBoundingBox = false;
                //Show bounding box for the target object.
                ((Model)myJupiter.Model).ShowBoundingBox = true;
                //Hide dubris control panel.
                dubrisFrame.Visible = false;
                //Display planet control panel.
                planetFrame.Visible = true;
                MouseInput.Instance.MouseClickEvent -= new HandleMouseClick(MouseClickHandler);
                UI2DRenderer.WriteText(new Vector2(540, 5), quitLabel, Color.Red, textFont3, Vector2.One * 0.5f);
                //Add panel controlled rotations.
                if (rotationDirection == "Clockwise")
                {
                    controlPanelJupiterRateClockwiseX += (float)gameTime.ElapsedGameTime.TotalSeconds * jupiterRotationSpeed1;
                    controlPanelJupiterRateClockwiseY += (float)gameTime.ElapsedGameTime.TotalSeconds * jupiterRotationSpeed2;
                    controlPanelJupiterRateClockwiseZ += (float)gameTime.ElapsedGameTime.TotalSeconds * jupiterRotationSpeed3;
                }
                if (rotationDirection == "Counterclockwise")
                {
                    controlPanelJupiterRateCounterclockwiseX -= (float)gameTime.ElapsedGameTime.TotalSeconds * jupiterRotationSpeed1;
                    controlPanelJupiterRateCounterclockwiseY -= (float)gameTime.ElapsedGameTime.TotalSeconds * jupiterRotationSpeed2;
                    controlPanelJupiterRateCounterclockwiseZ -= (float)gameTime.ElapsedGameTime.TotalSeconds * jupiterRotationSpeed3;
                }

                if (rotationAxis == "x-axis" || jupiterRotateX == true)
                {
                    if (rotationAxis == "x-axis")
                    {
                        jupiterRotationSpeed1 = rotationSpeed;
                        valueX = jupiterRotationSpeed1;
                    }
                    jupiterControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, controlPanelJupiterRateClockwiseX + controlPanelJupiterRateCounterclockwiseX);
                    jupiterRotateX = true;
                }
                if (rotationAxis == "y-axis" || jupiterRotateY == true)
                {
                    if (rotationAxis == "y-axis")
                    {
                        jupiterRotationSpeed2 = rotationSpeed;
                        valueY = jupiterRotationSpeed2;
                    }
                    jupiterControlPanel1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, controlPanelJupiterRateClockwiseY + controlPanelJupiterRateCounterclockwiseY);
                    jupiterRotateY = true;
                }
                if (rotationAxis == "z-axis" || jupiterRotateZ == true)
                {
                    if (rotationAxis == "z-axis")
                    {
                        jupiterRotationSpeed3 = rotationSpeed;
                        valueZ = jupiterRotationSpeed3;
                    }
                    jupiterControlPanel2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, controlPanelJupiterRateClockwiseZ + controlPanelJupiterRateCounterclockwiseZ);
                    jupiterRotateZ = true;
                }
            }
            if (label == "Mercury is picked")
            {
                //Unable all bounding boxes excepted the target object.
                ((Model)mySun.Model).ShowBoundingBox = false;
                ((Model)myEarth.Model).ShowBoundingBox = false;
                ((Model)myMoon.Model).ShowBoundingBox = false;
                ((Model)myMars.Model).ShowBoundingBox = false;
                ((Model)myJupiter.Model).ShowBoundingBox = false;
                coneNode.Model.ShowBoundingBox = false;
                torusNode.Model.ShowBoundingBox = false;
                cylinderNode.Model.ShowBoundingBox = false;
                boxNode.Model.ShowBoundingBox = false;
                //Show bounding box for the target object.
                ((Model)myMercury.Model).ShowBoundingBox = true;
                //Hide dubris control panel.
                dubrisFrame.Visible = false;
                //Display planet control panel.
                planetFrame.Visible = true;
                MouseInput.Instance.MouseClickEvent -= new HandleMouseClick(MouseClickHandler);
                UI2DRenderer.WriteText(new Vector2(540, 5), quitLabel, Color.Red, textFont3, Vector2.One * 0.5f);
                //Add panel controlled rotations.
                if (rotationDirection == "Clockwise")
                {
                    controlPanelMercuryRateClockwiseX += (float)gameTime.ElapsedGameTime.TotalSeconds * mercuryRotationSpeed1;
                    controlPanelMercuryRateClockwiseY += (float)gameTime.ElapsedGameTime.TotalSeconds * mercuryRotationSpeed2;
                    controlPanelMercuryRateClockwiseZ += (float)gameTime.ElapsedGameTime.TotalSeconds * mercuryRotationSpeed3;
                }
                if (rotationDirection == "Counterclockwise")
                {
                    controlPanelMercuryRateCounterclockwiseX -= (float)gameTime.ElapsedGameTime.TotalSeconds * mercuryRotationSpeed1;
                    controlPanelMercuryRateCounterclockwiseY -= (float)gameTime.ElapsedGameTime.TotalSeconds * mercuryRotationSpeed2;
                    controlPanelMercuryRateCounterclockwiseZ -= (float)gameTime.ElapsedGameTime.TotalSeconds * mercuryRotationSpeed3;
                }

                if (rotationAxis == "x-axis" || mercuryRotateX == true)
                {
                    if (rotationAxis == "x-axis")
                    {
                        mercuryRotationSpeed1 = rotationSpeed;
                        valueX = mercuryRotationSpeed1;
                    }
                    mercuryControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, controlPanelMercuryRateClockwiseX + controlPanelMercuryRateCounterclockwiseX);
                    mercuryRotateX = true;
                }
                if (rotationAxis == "y-axis" || mercuryRotateY == true)
                {
                    if (rotationAxis == "y-axis")
                    {
                        mercuryRotationSpeed2 = rotationSpeed;
                        valueY = mercuryRotationSpeed2;
                    }
                    mercuryControlPanel1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, controlPanelMercuryRateClockwiseY + controlPanelMercuryRateCounterclockwiseY);
                    mercuryRotateY = true;
                }
                if (rotationAxis == "z-axis" || mercuryRotateZ == true)
                {
                    if (rotationAxis == "z-axis")
                    {
                        mercuryRotationSpeed3 = rotationSpeed;
                        valueZ = mercuryRotationSpeed3;
                    }
                    mercuryControlPanel2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, controlPanelMercuryRateClockwiseZ + controlPanelMercuryRateCounterclockwiseZ);
                    mercuryRotateZ = true;
                }
            }
            if (label == "Dubris-Cone is picked")
            {
                //Unable all bounding boxes excepted the target object.
                ((Model)mySun.Model).ShowBoundingBox = false;
                ((Model)myEarth.Model).ShowBoundingBox = false;
                ((Model)myMoon.Model).ShowBoundingBox = false;
                ((Model)myMars.Model).ShowBoundingBox = false;
                ((Model)myJupiter.Model).ShowBoundingBox = false;
                ((Model)myMercury.Model).ShowBoundingBox = false;
                torusNode.Model.ShowBoundingBox = false;
                cylinderNode.Model.ShowBoundingBox = false;
                boxNode.Model.ShowBoundingBox = false;
                //Show bounding box for the target object.
                coneNode.Model.ShowBoundingBox = true;
                //Hide planet control panel.
                planetFrame.Visible = false;
                //Display dubris control panel.
                dubrisFrame.Visible = true;
                MouseInput.Instance.MouseClickEvent -= new HandleMouseClick(MouseClickHandler);
                UI2DRenderer.WriteText(new Vector2(540, 5), quitLabel, Color.Red, textFont3, Vector2.One * 0.5f);
                //Add panel controlled rotations.
                if (rotationDirection == "Clockwise")
                {
                    controlPanelConeRateClockwiseX += (float)gameTime.ElapsedGameTime.TotalSeconds * coneRotationSpeed1;
                    controlPanelConeRateClockwiseY += (float)gameTime.ElapsedGameTime.TotalSeconds * coneRotationSpeed2;
                    controlPanelConeRateClockwiseZ += (float)gameTime.ElapsedGameTime.TotalSeconds * coneRotationSpeed3;
                }
                if (rotationDirection == "Counterclockwise")
                {
                    controlPanelConeRateCounterclockwiseX -= (float)gameTime.ElapsedGameTime.TotalSeconds * coneRotationSpeed1;
                    controlPanelConeRateCounterclockwiseY -= (float)gameTime.ElapsedGameTime.TotalSeconds * coneRotationSpeed2;
                    controlPanelConeRateCounterclockwiseZ -= (float)gameTime.ElapsedGameTime.TotalSeconds * coneRotationSpeed3;
                }

                if (rotationAxis == "x-axis" || coneRotateX == true)
                {
                    if (rotationAxis == "x-axis")
                    {
                        coneRotationSpeed1 = rotationSpeed;
                        valueX = coneRotationSpeed1;
                    }
                    coneControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, controlPanelConeRateClockwiseX + controlPanelConeRateCounterclockwiseX);
                    coneRotateX = true;
                }
                if (rotationAxis == "y-axis" || coneRotateY == true)
                {
                    if (rotationAxis == "y-axis")
                    {
                        coneRotationSpeed2 = rotationSpeed;
                        valueY = coneRotationSpeed2;
                    }
                    coneControlPanel1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, controlPanelConeRateClockwiseY + controlPanelConeRateCounterclockwiseY);
                    coneRotateY = true;
                }
                if (rotationAxis == "z-axis" || coneRotateZ == true)
                {
                    if (rotationAxis == "z-axis")
                    {
                        coneRotationSpeed3 = rotationSpeed;
                        valueZ = coneRotationSpeed3;
                    }
                    coneControlPanel2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, controlPanelConeRateClockwiseZ + controlPanelConeRateCounterclockwiseZ);
                    coneRotateZ = true;
                }
                if (dubrisEscape == true)
                {
                    dubrisEscapeRate1 += (float)gameTime.ElapsedGameTime.TotalSeconds * (rotationRate + 4);
                    coneRotateSunNode.Scale = new Vector3((float)1.5, (float)1.5, (float)1.5);
                    coneControlPanel.Translation = new Vector3(0, 0, dubrisEscapeRate1);
                    coneControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, dubrisEscapeRate1);
                }
            }
            if (label == "Dubris-Torus is picked")
            {
                //Unable all bounding boxes excepted the target object.
                ((Model)mySun.Model).ShowBoundingBox = false;
                ((Model)myEarth.Model).ShowBoundingBox = false;
                ((Model)myMoon.Model).ShowBoundingBox = false;
                ((Model)myMars.Model).ShowBoundingBox = false;
                ((Model)myJupiter.Model).ShowBoundingBox = false;
                ((Model)myMercury.Model).ShowBoundingBox = false;
                coneNode.Model.ShowBoundingBox = false;
                cylinderNode.Model.ShowBoundingBox = false;
                boxNode.Model.ShowBoundingBox = false;
                //Show bounding box for the target object.
                torusNode.Model.ShowBoundingBox = true;
                //Hide planet control panel.
                planetFrame.Visible = false;
                //Display dubris control panel.
                dubrisFrame.Visible = true;
                MouseInput.Instance.MouseClickEvent -= new HandleMouseClick(MouseClickHandler);
                UI2DRenderer.WriteText(new Vector2(540, 5), quitLabel, Color.Red, textFont3, Vector2.One * 0.5f);
                //Add panel controlled rotations.
                if (rotationDirection == "Clockwise")
                {
                    controlPanelTorusRateClockwiseX += (float)gameTime.ElapsedGameTime.TotalSeconds * torusRotationSpeed1;
                    controlPanelTorusRateClockwiseY += (float)gameTime.ElapsedGameTime.TotalSeconds * torusRotationSpeed2;
                    controlPanelTorusRateClockwiseZ += (float)gameTime.ElapsedGameTime.TotalSeconds * torusRotationSpeed3;
                }
                if (rotationDirection == "Counterclockwise")
                {
                    controlPanelTorusRateCounterclockwiseX -= (float)gameTime.ElapsedGameTime.TotalSeconds * torusRotationSpeed1;
                    controlPanelTorusRateCounterclockwiseY -= (float)gameTime.ElapsedGameTime.TotalSeconds * torusRotationSpeed2;
                    controlPanelTorusRateCounterclockwiseZ -= (float)gameTime.ElapsedGameTime.TotalSeconds * torusRotationSpeed3;
                }

                if (rotationAxis == "x-axis" || torusRotateX == true)
                {
                    if (rotationAxis == "x-axis")
                    {
                        torusRotationSpeed1 = rotationSpeed;
                        valueX = torusRotationSpeed1;
                    }
                    torusControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, controlPanelTorusRateClockwiseX + controlPanelTorusRateCounterclockwiseX);
                    torusRotateX = true;
                }
                if (rotationAxis == "y-axis" || torusRotateY == true)
                {
                    if (rotationAxis == "y-axis")
                    {
                        torusRotationSpeed2 = rotationSpeed;
                        valueY = torusRotationSpeed2;
                    }
                    torusControlPanel1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, controlPanelTorusRateClockwiseY + controlPanelTorusRateCounterclockwiseY);
                    torusRotateY = true;
                }
                if (rotationAxis == "z-axis" || torusRotateZ == true)
                {
                    if (rotationAxis == "z-axis")
                    {
                        torusRotationSpeed3 = rotationSpeed;
                        valueZ = torusRotationSpeed3;
                    }
                    torusControlPanel2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, controlPanelTorusRateClockwiseZ + controlPanelTorusRateCounterclockwiseZ);
                    torusRotateZ = true;
                }
                if (dubrisEscape == true)
                {
                    dubrisEscapeRate2 += (float)gameTime.ElapsedGameTime.TotalSeconds * (rotationRate + 4);
                    torusRotateSunNode.Scale = new Vector3((float)1.5, (float)1.5, (float)1.5);
                    torusControlPanel.Translation = new Vector3(0, 0, dubrisEscapeRate2);
                    torusControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, dubrisEscapeRate2);
                }
            }
            if (label == "Dubris-Cylinder is picked")
            {
                //Unable all bounding boxes excepted the target object.
                ((Model)mySun.Model).ShowBoundingBox = false;
                ((Model)myEarth.Model).ShowBoundingBox = false;
                ((Model)myMoon.Model).ShowBoundingBox = false;
                ((Model)myMars.Model).ShowBoundingBox = false;
                ((Model)myJupiter.Model).ShowBoundingBox = false;
                ((Model)myMercury.Model).ShowBoundingBox = false;
                coneNode.Model.ShowBoundingBox = false;
                torusNode.Model.ShowBoundingBox = false;
                boxNode.Model.ShowBoundingBox = false;
                //Show bounding box for the target object.
                cylinderNode.Model.ShowBoundingBox = true;
                //Hide planet control panel.
                planetFrame.Visible = false;
                //Display dubris control panel.
                dubrisFrame.Visible = true;
                MouseInput.Instance.MouseClickEvent -= new HandleMouseClick(MouseClickHandler);
                UI2DRenderer.WriteText(new Vector2(540, 5), quitLabel, Color.Red, textFont3, Vector2.One * 0.5f);
                //Add panel controlled rotations.
                if (rotationDirection == "Clockwise")
                {
                    controlPanelCylinderRateClockwiseX += (float)gameTime.ElapsedGameTime.TotalSeconds * cylinderRotationSpeed1;
                    controlPanelCylinderRateClockwiseY += (float)gameTime.ElapsedGameTime.TotalSeconds * cylinderRotationSpeed2;
                    controlPanelCylinderRateClockwiseZ += (float)gameTime.ElapsedGameTime.TotalSeconds * cylinderRotationSpeed3;
                }
                if (rotationDirection == "Counterclockwise")
                {
                    controlPanelCylinderRateCounterclockwiseX -= (float)gameTime.ElapsedGameTime.TotalSeconds * cylinderRotationSpeed1;
                    controlPanelCylinderRateCounterclockwiseY -= (float)gameTime.ElapsedGameTime.TotalSeconds * cylinderRotationSpeed2;
                    controlPanelCylinderRateCounterclockwiseZ -= (float)gameTime.ElapsedGameTime.TotalSeconds * cylinderRotationSpeed3;
                }

                if (rotationAxis == "x-axis" || cylinderRotateX == true)
                {
                    if (rotationAxis == "x-axis")
                    {
                        cylinderRotationSpeed1 = rotationSpeed;
                        valueX = cylinderRotationSpeed1;
                    }
                    cylinderControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, controlPanelCylinderRateClockwiseX + controlPanelCylinderRateCounterclockwiseX);
                    cylinderRotateX = true;
                }
                if (rotationAxis == "y-axis" || cylinderRotateY == true)
                {
                    if (rotationAxis == "y-axis")
                    {
                        cylinderRotationSpeed2 = rotationSpeed;
                        valueY = cylinderRotationSpeed2;
                    }
                    cylinderControlPanel1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, controlPanelCylinderRateClockwiseY + controlPanelCylinderRateCounterclockwiseY);
                    cylinderRotateY = true;
                }
                if (rotationAxis == "z-axis" || cylinderRotateZ == true)
                {
                    if (rotationAxis == "z-axis")
                    {
                        cylinderRotationSpeed3 = rotationSpeed;
                        valueZ = cylinderRotationSpeed3;
                    }
                    cylinderControlPanel2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, controlPanelCylinderRateClockwiseZ + controlPanelCylinderRateCounterclockwiseZ);
                    cylinderRotateZ = true;
                }
                if (dubrisEscape == true)
                {
                    dubrisEscapeRate3 += (float)gameTime.ElapsedGameTime.TotalSeconds * (rotationRate + 4);
                    cylinderRotateSunNode.Scale = new Vector3((float)1.5, (float)1.5, (float)1.5);
                    cylinderControlPanel.Translation = new Vector3(0, 0, dubrisEscapeRate3);
                    cylinderControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, dubrisEscapeRate3);
                }
            }
            if (label == "Dubris-Box is picked")
            {
                //Unable all bounding boxes excepted the target object.
                ((Model)mySun.Model).ShowBoundingBox = false;
                ((Model)myEarth.Model).ShowBoundingBox = false;
                ((Model)myMoon.Model).ShowBoundingBox = false;
                ((Model)myMars.Model).ShowBoundingBox = false;
                ((Model)myJupiter.Model).ShowBoundingBox = false;
                ((Model)myMercury.Model).ShowBoundingBox = false;
                coneNode.Model.ShowBoundingBox = false;
                torusNode.Model.ShowBoundingBox = false;
                cylinderNode.Model.ShowBoundingBox = false;
                //Show bounding box for the target object.
                boxNode.Model.ShowBoundingBox = true;
                //Hide planet control panel.
                planetFrame.Visible = false;
                //Display dubris control panel.
                dubrisFrame.Visible = true;
                MouseInput.Instance.MouseClickEvent -= new HandleMouseClick(MouseClickHandler);
                UI2DRenderer.WriteText(new Vector2(540, 5), quitLabel, Color.Red, textFont3, Vector2.One * 0.5f);
                //Add panel controlled rotations.
                if (rotationDirection == "Clockwise")
                {
                    controlPanelBoxRateClockwiseX += (float)gameTime.ElapsedGameTime.TotalSeconds * boxRotationSpeed1;
                    controlPanelBoxRateClockwiseY += (float)gameTime.ElapsedGameTime.TotalSeconds * boxRotationSpeed2;
                    controlPanelBoxRateClockwiseZ += (float)gameTime.ElapsedGameTime.TotalSeconds * boxRotationSpeed3;
                }
                if (rotationDirection == "Counterclockwise")
                {
                    controlPanelBoxRateCounterclockwiseX -= (float)gameTime.ElapsedGameTime.TotalSeconds * boxRotationSpeed1;
                    controlPanelBoxRateCounterclockwiseY -= (float)gameTime.ElapsedGameTime.TotalSeconds * boxRotationSpeed2;
                    controlPanelBoxRateCounterclockwiseZ -= (float)gameTime.ElapsedGameTime.TotalSeconds * boxRotationSpeed3;
                }

                if (rotationAxis == "x-axis" || boxRotateX == true)
                {
                    if (rotationAxis == "x-axis")
                    {
                        boxRotationSpeed1 = rotationSpeed;
                        valueX = boxRotationSpeed1;
                    }
                    boxControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, controlPanelBoxRateClockwiseX + controlPanelBoxRateCounterclockwiseX);
                    boxRotateX = true;
                }
                if (rotationAxis == "y-axis" || boxRotateY == true)
                {
                    if (rotationAxis == "y-axis")
                    {
                        boxRotationSpeed2 = rotationSpeed;
                        valueY = boxRotationSpeed2;
                    }
                    boxControlPanel1.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, controlPanelBoxRateClockwiseY + controlPanelBoxRateCounterclockwiseY);
                    boxRotateY = true;
                }
                if (rotationAxis == "z-axis" || boxRotateZ == true)
                {
                    if (rotationAxis == "z-axis")
                    {
                        boxRotationSpeed3 = rotationSpeed;
                        valueZ = boxRotationSpeed3;
                    }
                    boxControlPanel2.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, controlPanelBoxRateClockwiseZ + controlPanelBoxRateCounterclockwiseZ);
                    boxRotateZ = true;
                }
                if (dubrisEscape == true)
                {
                    dubrisEscapeRate4 += (float)gameTime.ElapsedGameTime.TotalSeconds * (rotationRate + 4);
                    boxRotateSunNode.Scale = new Vector3((float)1.5, (float)1.5, (float)1.5);
                    boxControlPanel.Translation = new Vector3(0, 0, dubrisEscapeRate4);
                    boxControlPanel.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, dubrisEscapeRate4);
                }
            }
            if (label == "Nothing is selected")
            {
                //Unable all bounding boxes.
                ((Model)mySun.Model).ShowBoundingBox = false;
                ((Model)myEarth.Model).ShowBoundingBox = false;
                ((Model)myMoon.Model).ShowBoundingBox = false;
                ((Model)myMars.Model).ShowBoundingBox = false;
                ((Model)myJupiter.Model).ShowBoundingBox = false;
                ((Model)myMercury.Model).ShowBoundingBox = false;
                coneNode.Model.ShowBoundingBox = false;
                torusNode.Model.ShowBoundingBox = false;
                cylinderNode.Model.ShowBoundingBox = false;
                boxNode.Model.ShowBoundingBox = false;
                //Hide planet control panel.
                planetFrame.Visible = false;
                valueX = 0;
                valueY = 0;
                valueZ = 0;
            }
            if (label == "Sun is picked")
            {
                //Hide planet control panel.
                planetFrame.Visible = false;
                //Hide dubris control panel.
                dubrisFrame.Visible = false;
            }
            scene.Update(gameTime.ElapsedGameTime, gameTime.IsRunningSlowly, this.IsActive);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //Displaying system control panels.
            UI2DRenderer.WriteText(Vector2.Zero, label, Color.White, textFont, GoblinEnums.HorizontalAlignment.Center, GoblinEnums.VerticalAlignment.Top);
            //Control panels for attaching camera to planets and objects
            UI2DRenderer.WriteText(new Vector2(5, 30), "Press the following keys to attach camera to planets:", Color.AntiqueWhite, textFont, Vector2.One * 0.5f);
            UI2DRenderer.WriteText(new Vector2(5, 40), "'1' - Sun", Color.Gold, textFont, Vector2.One * 0.5f);
            UI2DRenderer.WriteText(new Vector2(5, 50), "'2' - Earth", Color.Gold, textFont, Vector2.One * 0.5f);
            UI2DRenderer.WriteText(new Vector2(5, 60), "'3' - Mercury", Color.Gold, textFont, Vector2.One * 0.5f);
            UI2DRenderer.WriteText(new Vector2(5, 70), "'4' - Mars", Color.Gold, textFont, Vector2.One * 0.5f);
            UI2DRenderer.WriteText(new Vector2(5, 80), "'5' - Jupiter", Color.Gold, textFont, Vector2.One * 0.5f);
            UI2DRenderer.WriteText(new Vector2(5, 90), "'6' - Moon", Color.Gold, textFont, Vector2.One * 0.5f);
            UI2DRenderer.WriteText(new Vector2(5, 100), "'7' - Debris Cylinder", Color.Gold, textFont, Vector2.One * 0.5f);
            UI2DRenderer.WriteText(new Vector2(5, 110), "'8' - Debris Cone", Color.Gold, textFont, Vector2.One * 0.5f);
            UI2DRenderer.WriteText(new Vector2(5, 120), "'9' - Debris Torus", Color.Gold, textFont, Vector2.One * 0.5f);
            UI2DRenderer.WriteText(new Vector2(5, 130), "'0' - Debris Box", Color.Gold, textFont, Vector2.One * 0.5f);
            //Control panels for the camera.
            UI2DRenderer.WriteText(new Vector2(5, 140), "Keyboard Camera Control", Color.AntiqueWhite, textFont, Vector2.One * 0.5f);
            UI2DRenderer.WriteText(new Vector2(5, 150), "'I' - Move camera in", Color.Gold, textFont, Vector2.One * 0.5f);
            UI2DRenderer.WriteText(new Vector2(5, 160), "'O' - Move camera out", Color.Gold, textFont, Vector2.One * 0.5f);
            UI2DRenderer.WriteText(new Vector2(5, 170), "'Left' - Move camera left", Color.Gold, textFont, Vector2.One * 0.5f);
            UI2DRenderer.WriteText(new Vector2(5, 180), "'Right' - Move camera right", Color.Gold, textFont, Vector2.One * 0.5f);
            UI2DRenderer.WriteText(new Vector2(5, 190), "'Up' - Move camera up", Color.Gold, textFont, Vector2.One * 0.5f);
            UI2DRenderer.WriteText(new Vector2(5, 200), "'Down' - Move camera down", Color.Gold, textFont, Vector2.One * 0.5f);
            UI2DRenderer.WriteText(new Vector2(5, 210), "'A' - Increase field of view", Color.Gold, textFont, Vector2.One * 0.5f);
            UI2DRenderer.WriteText(new Vector2(5, 220), "'S' - Decrease field of view", Color.Gold, textFont, Vector2.One * 0.5f);
            UI2DRenderer.WriteText(new Vector2(5, 230), "'R' - Reset All Planets", Color.AntiqueWhite, textFont, Vector2.One * 0.5f);
            //base.Draw(gameTime);
            scene.Draw(gameTime.ElapsedGameTime, gameTime.IsRunningSlowly);
        }
    }
}
