using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeGen
{

    public class BST
    {
        static ArrayList tempNodeStorage = new ArrayList();
        static BST tree = new BST();

        private Node Root;
        static string menuInput;
        static Random randomData = new Random();

        public BST()
        {
            this.Root = null;
        }

        private Node SearchBST(Node node, int data)
        {
            if (node != null)
            {


                if (data == node.leafNumber)
                {
                    //When Leaf Number Is Equal To Search Value Then Value Found
                    Console.WriteLine("User Data:" + data + " Vs " + "Leaf data" + node.leafNumber);
                    Console.WriteLine("Number Found: " + node.leafNumber);
                    return node;
                }
                if (data < node.leafNumber)
                {
                    //If The Searched Value Is Smaller Than Current Node Value Traverse Down The Left Side Of The Tree
                    Console.WriteLine("Smaller than Parent Value Go Down The Left side of Tree");
                    Console.WriteLine("User Data:" + data + " Vs " + "Leaf data left side:" + node.leafNumber);
                    //node.leftNode = Test(node.leftNode, data);
                    //Console.WriteLine(node.leafNumber);
                    node.leftNode = SearchBST(node.leftNode, data);



                }
                else
                {
                    //If Searched Value is Larger Than Current Node Value Traverse Right Down The Left Side Of The Tree
                    Console.WriteLine("Larger than Parant Value Go Down The Right side of Tree");
                    Console.WriteLine("User Data:" + data + " Vs " + "Leaf Data Right Side:" + node.leafNumber);

                    node.rightNode = SearchBST(node.rightNode, data);

                }

            }

            if (node == null)
            {
                // If Every Node Is Traversed In Tree And No Value Is Equal To Searched Node Then Node Is Value Is Not In Tree
                Console.WriteLine("Node Value Not Found Within tree");
            }


            return null;
        }

        private int MaxValue(Node node)
        {
            //Goes To The Bottom Value Of The Right Side Of Tree To Find Largest Value
            if (node.rightNode == null)
            {

                return node.leafNumber;

            }
            // If Value Is Not Null Recursively Traverse The Tree And Repeat Check
            return MaxValue(node.rightNode);
        }

        private int MinValue(Node node)
        {
            //Goes To The Bottom Value Of The Left Side Of Tree To Find Smallest Value
            if (node.leftNode == null)
            {
                return node.leafNumber;
            }
            // If Value Is Not Null Recursively Traverse The Tree And Repeat Check
            return (MinValue(node.leftNode));
        }

        private Node AddNode(Node node, int data)
        {
            //If Tree Instance Created (Check If Root Is Null) Then Compare Node Value
            if (node != null)
            {
                // If New Value Is Smaller Than Current Node Value Then Traverse Left Of The Tree
                if (data < node.leafNumber)
                {
                    // Recursively Traverse Tree Left And Repeat Leaf Value Comparision
                    node.leftNode = AddNode(node.leftNode, data);
                }
                else
                {
                    // If New Value Is Larger Than Current Value 
                    // Traverse Recursively Down Right Side Of Tree And Repeat Checks
                    node.rightNode = AddNode(node.rightNode, data);
                }



                return node;
            }
            // If Current Node Is Null Return New Node With The New Data
            // If Root == Null Create New Root Value With The New Data
            return new Node(data);
        }

        private Node DeleteNode(Node node, int data)
        {
            if (node != null)
            {

                if (data == node.leafNumber)
                {
                    //Node to be deleted has no children
                    if (node.leftNode == null && node.rightNode == null)
                    {
                        Console.WriteLine("Deleteing Node:" + node.leafNumber);
                        Console.WriteLine("Node Has No Children!");
                        node = null;

                        // delete node 
                    }
                    //node to be deleted has both children
                    else if (node.leftNode != null && node.rightNode != null)
                    {
                        Console.WriteLine("Deleteing Node:" + node.leafNumber);
                        Console.WriteLine("Node Has Both Children! Node Will Be Replaced By Next In Order Sucessor.");
                        node.leafNumber = MinValue(node.rightNode);
                        node.rightNode = DeleteNode(node.rightNode, node.leafNumber);

                    }
                    //node to be deleted has one child
                    else if (node.leftNode == null)
                    {
                        Console.WriteLine("Deleteing Node:" + node.leafNumber);
                        Console.WriteLine("Node Has No Left Child!");
                        Console.WriteLine("Before Removal The Value Is: " + node.leafNumber);
                        node.leafNumber = node.rightNode.leafNumber;
                        Console.WriteLine("The Left Child (" + node.leafNumber + ")Will Replace The Chosen Node And Will Be Removed From It's Original Postion.");
                        Console.WriteLine("");

                        node.rightNode = null;
                        //return node;
                    }
                    else //(node.rightNode == null)
                    {
                        Console.WriteLine("Deleteing Node:" + node.leafNumber);
                        Console.WriteLine("Node Has No Right Child!");
                        Console.WriteLine("Before Removal The Node Value Is: " + node.leafNumber);
                        node.leafNumber = node.leftNode.leafNumber;
                        Console.WriteLine("The Left Child (" + node.leafNumber + ")Will Replace The Chosen Node And Will Be Removed From It's Original Postion.");
                        Console.WriteLine("");
                        node.leftNode = null;
                        //return node;
                    }
                }
                else if (data < node.leafNumber)
                {
                    // go left

                    node.leftNode = DeleteNode(node.leftNode, data);
                }
                else
                {
                    //go right

                    node.rightNode = DeleteNode(node.rightNode, data);
                }


                return node;


            }

            Console.WriteLine("Error: Node Not Found Please Try Again!");
            DeleteNodeInput();
            return node;

        }

        private static void GenerateRandomBST()

        {
            // Counter Used To Determine Quantity Of Nodes In The Tree
            int treeSizeCounter = 0;
            int i = 0;

            Console.WriteLine("BST Random Generation" + "\n");
            Console.WriteLine("Input BST Node Count (Integer) OR [R] Random Node Count OR [Q] Return To Menu");
            // User Choice Of Random Tree Size Or Chosen Amount
            string input = Console.ReadLine();
            // Value Made To Upper To Avoid Input Mismatch 
            input = input.ToUpper();
            // Checks If Input Is Integer Value (Count)
            if (int.TryParse(input, out int value))
            {

                Console.WriteLine("Generating Tree based On User Chosen Node Count");
                treeSizeCounter = Convert.ToInt32(input);
                if (treeSizeCounter < 0)
                {
                    // Checks If User Input Is Negative And If True Return To The Start Of The Method
                    Console.WriteLine("Error: Please Enter Postive Integer Value! Chosen Node Count Must Be A Postive Value.");
                    GenerateRandomBST();
                }
                // Else Store Value And Display It To User
                Console.WriteLine("Node Count:" + treeSizeCounter);
                treeSizeCounter = treeSizeCounter - 1;

            }
            else if (input.Equals("R"))
            {
                // If User Inputs "R" Then User Generates Random Size Count Between 1 and 100
                // Limit Of Counter Size To Maintain Performance When Generating Tree
                Console.WriteLine("Generating Tree based Random Generated Node Count");
                treeSizeCounter = randomData.Next(1, 100);
                treeSizeCounter = treeSizeCounter - 1;
                Console.WriteLine("Node Count:" + treeSizeCounter);

            }

            else if (input.Equals("Q"))
            {
                // If Input "Q" Returning To Main Menu Before Tree Construction
                Console.WriteLine("Returning To Menu ....");
                RunProgram();

            }

            else
            {
                // If Input None Of The Required Values Then Throw Error And Restart Method
                Console.WriteLine("Error: Incorrect User Input ! Please specify the node count of Random BST By Entering Integer Value['int'] OR Choose Random Node Count ['R'] OR Choose to Quit and retur menu['Q']");
                GenerateRandomBST();

            }
            // Set Initial Root Value With Random Generated Value Between 1 and 1000
            // Leaf Value Limited To Increase Generation Peformance And Readability In Console Print
            tree.Root = tree.AddNode(tree.Root, randomData.Next(1, 1000));
            // Add Nodes To Tree By The Amount Chosen/Random Node Count Value
            while (i < treeSizeCounter)
            {

                tree.AddNode(tree.Root, randomData.Next(1, 1000));

                i++;

            }



            // Check If Tree Is Completely Degenerate And Throw Warning If True
            tree.RandomBSTCompleteDegenTest(tree.Root);





        }

        private Node DegenerateBuild(Node node)
        {
            // Method Is Used To Generate A Complete Degenerate BST 
            // Limit Data Contained In Node Between 1 And 100O To Improve Perfromance Generating Tree 
            //And Improve Console Print Readabilty
            int degenData = randomData.Next(1, 1000);
            // Checks If New Value is Larger Than Current Value And If True Add Value
            if (degenData > node.leafNumber)
            {
                tree.AddNode(tree.Root, degenData);
            }
            else
            {
                // Else Call Method Recursively And Repeat Step
                DegenerateBuild(node);
            }
            return node;
        }

        private static void DegenerateGeneration()
        {
            //DegenrateGeneration Method Is Used To Determine The Size Of Degenerate Tree
            // Counter Used To Determine Quantity Of Nodes In The Tree
            int treeSizeCounter = 0;
            int i = 0;

            Console.WriteLine("BST Random Generation" + "\n");
            Console.WriteLine("Input BST Node Count (Integer) OR [R] Random Node Count OR [Q] Return To Menu");
            // User Choice Of Random Tree Size Or Chosen Amount
            string input = Console.ReadLine();
            // Value Made To Upper To Avoid Input Mismatch 
            input = input.ToUpper();
            // Checks If Input Is Integer Value (Count)
            if (int.TryParse(input, out int value))
            {

                Console.WriteLine("Generating Tree based On User Chosen Node Count");
                treeSizeCounter = Convert.ToInt32(input);
                if (treeSizeCounter < 0)
                {
                    // Checks If User Input Is Negative And If True Return To The Start Of The Method
                    Console.WriteLine("Error: Please Enter Postive Integer Value! Chosen Node Count Must Be A Postive Value.");
                    GenerateRandomBST();
                }
                // Else Store Value And Display It To User
                Console.WriteLine("Node Count:" + treeSizeCounter);
                treeSizeCounter = treeSizeCounter - 1;

            }
            else if (input.Equals("R"))
            {
                // If User Inputs "R" Then User Generates Random Size Count Between 1 and 100
                // Limit Of Counter Size To Maintain Performance When Generating Tree
                Console.WriteLine("Generating Tree based Random Generated Node Count");
                treeSizeCounter = randomData.Next(1, 100);
                treeSizeCounter = treeSizeCounter - 1;
                Console.WriteLine("Node Count:" + treeSizeCounter);

            }

            else if (input.Equals("Q"))
            {
                // If Input "Q" Returning To Main Menu Before Tree Construction
                Console.WriteLine("Returning To Menu ....");
                RunProgram();

            }

            else
            {
                // If Input None Of The Required Values Then Throw Error And Restart Method
                Console.WriteLine("Error: Incorrect User Input ! Please specify the node count of Random BST By Entering Integer Value['int'] OR Choose Random Node Count ['R'] OR Choose to Quit and retur menu['Q']");
                DegenerateGeneration();

            }
            tree.Root = tree.AddNode(tree.Root, randomData.Next(1, 1000));
            while (i < treeSizeCounter)
            {
                // Add Nodes To Tree By The Amount Chosen/Random Node Count Value
                // Degenerate Adding Method Used To Create Unbalanced Tree

                tree.DegenerateBuild(tree.Root);

                i++;

            }
            // Check If Tree Is Completely Degenerate And Throw Warning If True (Method Used For Checking Method Functionaility)
            // tree.RandomBSTCompleteDegenTest(tree.Root);
        }

        private void PostOrderTraversal(Node node)
        {
            // If Root Contains Value  Traverse And Print Or Node Value exist


            if (node != null)
            {
                //Visit And Traverse Recursively The Left Subtree First And Print! 
                //Then Visit And Travers Recursively The Right Subtree And Print!
                //Then Print Root Node Last
                // Simulates The Tree Values Being Displayed In Levels Starting At The Bottom And Ending At The Top
                this.PostOrderTraversal(node.leftNode);
                this.PostOrderTraversal(node.rightNode);
                Console.Write(node.leafNumber + " ");
                // Postfix Expression Found
                // Time Complexity = O(N) "N Is The Node Count"
                // Auxilary Space = O(h) "H Is The Height Of The Tree"
            }
            // Else Stop
            return;


        }

        private void InOrderTraversal(Node node)
        {
            //Postion Starts At Root Node If Tree Instance Is Created Or Node Value exist
            if (node != null)
            {
                // Recursively Travel The Left Side Of Tree Until Reaching Null!
                // Print Each Value From Bottom Until Root
                this.InOrderTraversal(node.leftNode);
                Console.Write(node.leafNumber + " ");
                // Then Recursively Travel The Right Side Of Tree Printing Each Value From Top To Bottom!
                // Bottom Right Value Being Last
                this.InOrderTraversal(node.rightNode);

                //For A BST This Will Print The Values From Smallest To Largest (This Is The Case For Our Program !)
                // Time Complexity = O(N) "N Is The Node Count"
                // Auxilary Space = O(h) "H Is The Height Of The Tree"

            }
            return;
            // Else Stop
        }

        private void PreOrderTraversal(Node node)
        {
            // If Root Contains Value Traverse And Print Or Node Value exist
            if (node != null)
            {
                // Print Root Value First
                Console.Write(node.leafNumber + " ");
                // Traverse From Top To Bottom  Recursively Down The Left Sub Tree And Print Each Value Until Null
                this.PreOrderTraversal(node.leftNode);
                // Traverse From Top To Bottom  Recursively Down The Right Sub Tree And Print Each Value Until Null
                this.PreOrderTraversal(node.rightNode);

                // Root Will Always Be Printed First !
                // Time Complexity = O(N) "N Is The Node Count"
                // Auxilary Space = O(h) "H Is The Height Of The Tree"

            }

            return;
            // Else Stop
        }

        private static void FixedBalancedTree()
        {

            // This Is A Hard Coded BST Tree Construction Method
            //Set BST Root
            tree.Root = tree.AddNode(tree.Root, 50);
            //Add BST Nodes


            tree.AddNode(tree.Root, 45);
            tree.AddNode(tree.Root, 55);
            tree.AddNode(tree.Root, 40);
            tree.AddNode(tree.Root, 60);
            tree.AddNode(tree.Root, 35);
            tree.AddNode(tree.Root, 65);
            tree.AddNode(tree.Root, 30);
            tree.AddNode(tree.Root, 70);
            tree.AddNode(tree.Root, 25);
            tree.AddNode(tree.Root, 75);
            tree.AddNode(tree.Root, 20);


        }

        private bool Balanced(Node node)
        {
            // Checks If Tree Is Considered Perfectly Balanced And Returns Bool
            // Calculates The Max Depth On Both Sides Of Tree 
            int leftDepth = MaxDepth(node.leftNode);
            int rightDepth = MaxDepth(node.rightNode);

            // Checks If Tree Is Balanced By Compairing The Depth Of The Left And Right Side
            // If One Side Has A Greater Difference In Size Which Is Larger Than 1 Then Balance == False
            // Else If Difference Is 1 Or If Left And Right Value Is Equal Then Balance == True
            if (Math.Abs(leftDepth - rightDepth) > 1)
            {

                return false;
            }
            else
            {


                return true;
            }
        }

        private int MaxDepth(Node node)
        {

            // If Tree Is Generated  Or Node Value exist
            if (node != null)
            {
                // Traverse Left Side Of Tree And Count Side
                int leftDepth = MaxDepth(node.leftNode);
                // Traverse Right Of Tree And Count Side
                int rightDepth = MaxDepth(node.rightNode);


                if (leftDepth > rightDepth)
                {
                    // If Left Side Has Larger Countt Then Return Left Depth As Max Depth Of Tree
                    return (leftDepth + 1);
                }

                else
                {
                    // If Right Side Of Tree Has Larger Count Then Return Right Depth As MAX Depth
                    return (rightDepth + 1);
                }

            }
            else
            {
                // Node Node Exist Then Return 0 
                return 0;
            }
        }

        private int NodeCount(Node node)
        {

            // If Tree Is Generated  Or Node Value exist
            if (node != null)
            {
                // Recursively Travel Down Left Side Of Tree And Count Each Node Until Node = Null!
                int leftDepth = NodeCount(node.leftNode);
                //Recursively Travel Down Right Side Of Tree And Count Each Node Until Node = Null!
                int rightDepth = NodeCount(node.rightNode);

                // Return The sum of (Add NodeCount Of Left And Right Side Of Tree Plus Root For Node Count Total)
                return leftDepth + rightDepth + 1;

            }
            else
            {
                // Tree Has Zero Nodes
                return 0;
            }
        }

        private static void SearchInput()
        {
            Console.WriteLine("Enter An Integer Value You Wish To Search");
            Console.WriteLine("Exit Enter [Q] ");
            // Take User Input For Value That Needs To Be Searched
            string newLeafValue = Console.ReadLine();
            // Input Turned Into Upper Case To Avoid Input Mismatch
            newLeafValue = newLeafValue.ToUpper();
            if (int.TryParse(newLeafValue, out int value))
            {
                // Checks If Integer ! If True Calls Search Method To Try Find User Inputed Value

                Console.WriteLine("Searching For Value In BST... " + newLeafValue);
                tree.SearchBST(tree.Root, Convert.ToInt32(newLeafValue));
                DisplayMenu();
                Menu();

            }
            // If Input is Q Return To Inside Tree Menu (Call Menu Method) 
            // Ignores Input Case Type
            else if (newLeafValue.Equals("Q", StringComparison.CurrentCultureIgnoreCase))
            {

                Console.WriteLine("Return To Menu! Goodbye....");
                RunProgram();

            }
            // Else Throw And Error Message And Restart Search Input Method
            else
            {
                Console.WriteLine("User Input Is Incorrect Type '" + newLeafValue + "'" + "Please Enter An Integer Value");
                SearchInput();
            }

        }

        private static void DeleteNodeInput()
        {
            Console.WriteLine("Enter An Integer Value You Wish To Remove");
            Console.WriteLine("Exit Enter [Q] ");
            // Take User Input For Value That Needs To Be Searched And Deleted
            string LeafValueToBeRemoved = Console.ReadLine();
            // Input Turned Into Upper Case To Avoid Input Mismatch
            LeafValueToBeRemoved.ToUpper();
            if (int.TryParse(LeafValueToBeRemoved, out int value))
            {
                // Checks If Integer ! If True Calls Node Deltion Method To Try Find User Inputed Value And Delete It From Tree
                tree.DeleteNode(tree.Root, Convert.ToInt32(LeafValueToBeRemoved));
                DisplayMenu();
                Menu();

            }
            else if (LeafValueToBeRemoved.Equals("Q", StringComparison.CurrentCultureIgnoreCase))
            {
                // If Input is Q Return To Inside Tree Menu (Call Menu Method) 
                // Ignores Input Case Type
                Console.WriteLine("Return To Menu! Goodbye....");
                RunProgram();

            }
            else
            {
                // Else Throw And Error Message And Restart Input Method
                Console.WriteLine("User Input Is Incorrect Type '" + LeafValueToBeRemoved + "'" + "Please Enter An Integer Value");
                DeleteNodeInput();
            }



        }

        private static void InputNode()
        {
            Console.WriteLine("Enter an integer value to add to the BST");
            Console.WriteLine("Exit Enter [Q] ");
            // Take User Input For Value That Needs To Be Added To Tree
            string newLeafValue = Console.ReadLine();
            // Input Turned Into Upper Case To Avoid Input Mismatch
            newLeafValue = newLeafValue.ToUpper();
            if (int.TryParse(newLeafValue, out int value))
            {
                // Checks If Integer ! If True Add Node Method To Add New Value Correctly To BST
                // String Input Value Is Converted To Integer Value To Match Node Leaf Number Type
                Console.WriteLine("Adding new leaf value... " + newLeafValue);
                tree.AddNode(tree.Root, Convert.ToInt32(newLeafValue));
                Console.WriteLine("In order ");
                tree.InOrderTraversal(tree.Root);

            }
            // If Input is Q Return To Inside Tree Menu (Call Menu Method) 
            // Ignores Input Case Type
            else if (newLeafValue.Equals("Q", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Return To Menu! Goodbye....");
                RunProgram();

            }
            // Else Throw And Error Message And Restart Add Node Input Method
            else
            {
                Console.WriteLine("User Input Is incorrect type '" + newLeafValue + "'" + "please enter an integer value");
                InputNode();
            }

        }

        private static void GenerateFixedTree()
        {
            // Generates Hard Coded BST 
            //Set BST Root
            tree.Root = tree.AddNode(tree.Root, 37);
            //Add BST Nodes


            tree.AddNode(tree.Root, 47);
            tree.AddNode(tree.Root, 22);
            tree.AddNode(tree.Root, 32);
            tree.AddNode(tree.Root, 12);
            tree.AddNode(tree.Root, 25);
            tree.AddNode(tree.Root, 42);
            tree.AddNode(tree.Root, 57);
            tree.AddNode(tree.Root, 52);
            tree.AddNode(tree.Root, 67);
            tree.AddNode(tree.Root, 2);
            tree.AddNode(tree.Root, 27);
            //tree.PreOrderTraversal(tree.Root);
            //Console.WriteLine("BST Stats: " + "Tree Depth:" + tree.MaxDepth(tree.Root) + "|Tree Node Count:" + tree.NodeCount(tree.Root) + "|Max BST Node Value:" + tree.MaxValue(tree.Root) + "|Min BST Node Value:" + tree.MinValue(tree.Root) + "|BST Root Value:" + tree.Root.leafNumber + "|BST Balanced:" + tree.Balanced(tree.Root));

            //tree.BalanceTree(tree.Root);

        }

        private static void UserTree()
        {
            // Driver Method To Consturct Tree Based On User Individual Input
            // User Creates Root Of BST First
            ConstructRoot();
            // Then Constructs Node Of BST 
            ConstructNodes();

        }

        private static void ConstructRoot()
        {
            Console.WriteLine("BST User Creation" + "\n");
            Console.WriteLine("Input BST Root Value(Integer) OR [Q] Return To Menu");
            // Take User Input For Root Value Of New Tree
            string userInput = Console.ReadLine();
            // Input Turned Into Upper Case To Avoid Input Mismatch
            userInput = userInput.ToUpper();
            if (int.TryParse(userInput, out int value))
            {
                // Checks If Integer ! If True Calls Add Node Method To Set The Root Value Of New Tree
                tree.Root = tree.AddNode(tree.Root, Convert.ToInt32(userInput));
                Console.WriteLine("Your Custom Tree Root Value:" + tree.Root.leafNumber);
                Console.WriteLine("\n" + "Please Enter Value To Be Contained In The New Node");

            }
            // If Input is Q Return To Inside Tree Menu (Return To Start) 
            else if (userInput.Equals("Q"))
            {
                Console.WriteLine("Returning To Menu...");
                RunProgram();
            }
            else
            {
                // Else Throw And Error Message And Restart Construct Root Method
                Console.WriteLine("Error: Incorrect Value ! Please Enter Integer Value to Construct Root.");
                ConstructRoot();

            }

        }

        private static void ConstructNodes()
        {
            Console.WriteLine("BST User Creation");
            int run = 1;


            // Continually Request User To Input New Node Values
            while (run == 1)
            {
                Console.WriteLine("Input BST Node Value(Integer) OR [F] To Generate Finished Tree OR [Q] Return To Menu");
                // Take User Input For Root Value Of New Tree
                string userInput = Console.ReadLine();
                // Input Turned Into Upper Case To Avoid Input Mismatch
                userInput = userInput.ToUpper();

                if (int.TryParse(userInput, out int value1))
                {
                    // Checks If Integer ! If True Calls Add Node Method To Set The New Node Value Of New Tree

                    tree.AddNode(tree.Root, Convert.ToInt32(userInput));

                    Console.WriteLine("Your Custom Node Value:" + tree.Root.leafNumber);
                    if (tree.Root.leftNode == null && tree.Root.rightNode == null)
                    {
                        //Checks If Root Value If So Print Out Custom Print Feedback For Root/Tree
                        Console.WriteLine("");
                        Console.WriteLine("Your Custom Tree Root Value:" + tree.Root.leafNumber);
                        Console.WriteLine("BST Stats: " + "Tree Depth:" + tree.MaxDepth(tree.Root) + "|Tree Node Count:" + tree.NodeCount(tree.Root) + "|Max BST Node Value:" + tree.MaxValue(tree.Root) + "|Min BST Node Value:" + tree.MinValue(tree.Root));
                        Console.WriteLine("\n" + "Please Enter Value To Be Contained In The New Node");
                        Console.WriteLine("");

                    }
                    else
                    {
                        //Else Print Out Custom Print Feedback For Nodes/Tree
                        Console.WriteLine("");
                        Console.WriteLine("Your Last Custom Node Value:" + tree.Root.leafNumber);
                        Console.WriteLine("BST Stats: " + "Tree Depth:" + tree.MaxDepth(tree.Root) + "|Tree Node Count:" + tree.NodeCount(tree.Root) + "|Max BST Node Value:" + tree.MaxValue(tree.Root) + "|Min BST Node Value:" + tree.MinValue(tree.Root));
                        Console.WriteLine("\n" + "Please Enter Value To Be Contained In The New Node");
                        Console.WriteLine("");


                    }






                }

                else if (userInput.Equals("Q"))
                {
                    // Return To Intro Menu
                    Console.WriteLine("Returning To Menu...");
                    RunProgram();
                }

                else if (userInput.Equals("F"))
                {
                    // Else If User Input "F" Then A Test Is Called To Check If BST Is Completly Degenerate ...
                    // If User Wishes To Continue The User Is Taken To The BST Instance Menu's And Tree Is Generated
                    tree.UserBSTCompleteDegenTest(tree.Root);
                    DisplayMenu();
                    Menu();
                }
                else
                {
                    // Else Error is Thrown And ConstructNode Method Restarts
                    Console.WriteLine("Error: Incorrect Value ! Please Enter Integer Value to Construct Node.");
                    ConstructNodes();
                }





            }

        }

        private void UserBSTCompleteDegenTest(Node node)
        {
            // Test For User Constructed Tree For Complete Degenerate Tree


            if (node != null)
            {
                if (Root.leftNode == null && Root.rightNode == null)
                {
                    // If Root Has Neither Children Then Return Because It Can't Logically Be Degenerate As It ...
                    // Is Only One Node
                    return;

                }
                else if (Root.leftNode == null || Root.rightNode == null)
                {
                    // If The Root Value Only Has One Child Then The Tree Is Degenerate As It Is ...
                    // As Effcient As A Linked List 
                    Console.WriteLine("Warning: You will generate a Complete Degenerate BST!");
                    Console.WriteLine("Are you sure you want to continue to generate this tree? [Y]es Continue: |  [R]estart: | [N]o: Return To Menu ");
                    //User Is Prompted To Choose To Continue To Construct The Complete Degenerate BST
                    string input = Console.ReadLine();
                    input = input.ToUpper();

                    if (input.Equals("Y"))
                    {
                        // If "Y" Continue To Generate Tree
                        Console.WriteLine("Generating Custom BST ....");


                    }
                    else if (input.Equals("R"))
                    {
                        // If "R" Then Tree Construction Restarts 
                        Console.WriteLine("Restarting Tree Construction...");
                        UserTree();
                    }
                    else if (input.Equals("N"))
                    {
                        // If "N" User Returns To Intro Menu
                        Console.WriteLine("Returning To Menu...");
                        RunProgram();
                    }
                    else
                    {
                        // Else Error Is Thrown And User Is Prompted To Input The Correct Value
                        Console.WriteLine("Error: Incorrect Input Please Enter [Y]es Continue: |  [R]estart: | [Q]uit: Return");
                        tree.UserBSTCompleteDegenTest(tree.Root);
                    }

                }



            }

            return;

        }

        private void RandomBSTCompleteDegenTest(Node node)
        {
            // Test For Randomly Constructed Tree For Complete Degenerate Tree

            if (node != null)
            {
                if (Root.leftNode == null && Root.rightNode == null)
                {
                    // If Root Has Neither Children Then Return Because It Can't Logically Be Degenerate As It ...
                    // Is Only One Node
                    return;

                }
                else if (Root.leftNode == null || Root.rightNode == null)
                {
                    // If The Root Value Only Has One Child Then The Tree Is Degenerate As It Is ...
                    // As Effcient As A Linked List 
                    Console.WriteLine("Warning: You will generate a Complete Degenerate BST!");
                    Console.WriteLine("Are you sure you want to continue to generate this tree? [Y]es Continue: |  [R]estart: | [N]o: Return To Menu ");
                    //User Is Prompted To Choose To Continue To Construct The Complete Degenerate BST
                    string input = Console.ReadLine();
                    input = input.ToUpper();

                    if (input.Equals("Y"))
                    {
                        // If "Y" Continue To Generate Tree
                        Console.WriteLine("Generating Random BST ....");


                    }
                    else if (input.Equals("R"))
                    {
                        // If "R" Then Tree Construction Restarts 
                        Console.WriteLine("Restarting Tree Construction...");
                        GenerateRandomBST();
                    }
                    else if (input.Equals("N"))
                    {
                        Console.WriteLine("Returning To Menu...");
                        RunProgram();
                    }
                    else
                    {
                        // Else Error Is Thrown And User Is Prompted To Input The Correct Value
                        Console.WriteLine("Error: Incorrect Input Please Enter [Y]es Continue: |  [R]estart: | [Q]uit: Return");
                        tree.UserBSTCompleteDegenTest(tree.Root);
                    }

                }



            }

            return;

        }

        private static void Menu()
        {
            // Switch Case Menu For User Interaction With Already Created BST
            string menuInput = "";

            Console.WriteLine("");
            // BST Statistics Are Printed
            Console.WriteLine("BST Stats: " + "Tree Depth:" + tree.MaxDepth(tree.Root) + "|Tree Node Count:" + tree.NodeCount(tree.Root) + "|Max BST Node Value:" + tree.MaxValue(tree.Root) + "|Min BST Node Value:" + tree.MinValue(tree.Root) + "|BST Root Value:" + tree.Root.leafNumber + "|BST Balanced:" + tree.Balanced(tree.Root)
                );
            // User Input User For Input Of Menu
            menuInput = Console.ReadLine();
            //User Input Is Made To Upper Case To Prevent Input Mismatch
            menuInput = menuInput.ToUpper();


            // If Input Is Integer Or Q  Then Continue With Switch Case Menu
            if (int.TryParse(menuInput, out int value) || menuInput.Equals("Q"))
            {

                //BST tree = new BST();

                switch (menuInput.ToUpper())
                {

                    case "1":
                        // Calls Display Menu So User Knows How To Navigate After The Method Is Complete
                        // Calls Inorder Method And Prints Values
                        // Restarts Menu Method For User To Decide Next Action On BST
                        DisplayMenu();
                        Console.WriteLine("Inorder ");
                        tree.InOrderTraversal(tree.Root);
                        Menu();

                        break;
                    case "2":
                        // Calls Display Menu So User Knows How To Navigate After The Method Is Complete
                        // Calls Preorder Method And Prints Values
                        // Restarts Menu Method For User To Decide Next Action On BST
                        DisplayMenu();
                        Console.WriteLine("Preorder ");
                        tree.PreOrderTraversal(tree.Root);
                        Menu();
                        break;
                    case "3":
                        // Calls Display Menu So User Knows How To Navigate After The Method Is Complete
                        // Calls Post Order Method And Prints Values
                        // Restarts Menu Method For User To Decide Next Action On BST
                        DisplayMenu();
                        Console.WriteLine("Post Order");
                        tree.PostOrderTraversal(tree.Root);
                        Menu();
                        break;
                    case "4":
                        // Calls Display Menu So User Knows How To Navigate After The Method Is Complete
                        // Calls Inorder , Preorder And Post Order Methods And Prints Values
                        // Restarts Menu Method For User To Decide Next Action On BST
                        DisplayMenu();
                        Console.WriteLine("");
                        Console.WriteLine("Inorder ");
                        tree.InOrderTraversal(tree.Root);
                        Console.WriteLine("");
                        Console.WriteLine("Preorder ");
                        tree.PreOrderTraversal(tree.Root);
                        Console.WriteLine("");
                        Console.WriteLine("Post Order");
                        tree.PostOrderTraversal(tree.Root);
                        Menu();
                        break;
                    case "5":
                        // Calls Display Menu So User Knows How To Navigate After The Method Is Complete
                        //User Input Method Is Called So User Can Add New Nodes TO BST
                        // Restarts Menu Method For User To Decide Next Action On BST
                        DisplayMenu();
                        Console.WriteLine("");
                        Console.WriteLine("Add To Tree");
                        Console.Write("Current Tree Values:");
                        Console.WriteLine("");
                        tree.PostOrderTraversal(tree.Root);
                        InputNode();
                        Menu();
                        break;
                    case "6":
                        // Calls Display Menu So User Knows How To Navigate After The Method Is Complete
                        // User Delete Node Method Is Called So User Can Remoeve Nodes From BST
                        // List Of Current Nodes Printed In Order So User Knows What Values Can Be Deleted
                        // Restarts Menu Method For User To Decide Next Action On BST
                        DisplayMenu();
                        Console.WriteLine("");
                        Console.WriteLine("Delete Value From Tree");
                        Console.WriteLine("");
                        Console.Write("Current Tree Values:");
                        tree.InOrderTraversal(tree.Root);
                        DeleteNodeInput();
                        Menu();
                        break;
                    case "7":
                        // Calls Display Menu So User Knows How To Navigate After The Method Is Complete
                        // User Seardch Method Is Called So User Can Check If A Specfic Node Value Exits In BST
                        // Restarts Menu Method For User To Decide Next Action On BST
                        DisplayMenu();
                        Console.WriteLine("");
                        Console.WriteLine("Search Tree");
                        Console.Write("Current Tree Values:");
                        Console.WriteLine("");
                        //tree.PostOrderTraversal(tree.Root);
                        SearchInput();
                        Menu();
                        break;
                    case "8":
                        // Calls Display Menu So User Knows How To Navigate After The Method Is Complete
                        // Intro Menu Is Called So User Can Choose A Different Tree Generation Type Or Exit 
                        DisplayMenu();
                        Console.WriteLine("Returning To Start Menu ....");
                        RunProgram();
                        break;
                    case "Q":
                    case "0":
                        // Two Forms Of Exit "Q" Or Exit Via Input
                        // User Leaves Console APlication And System Is Shutdown
                        Console.WriteLine("Exit BST Enviroment! Goodbye ....");
                        Environment.Exit(1);
                        break;
                    default:
                        // If Value Is Number But Not Within The Switch Case Menu Start Again
                        Menu();
                        break;

                }
            }
            else
            {
                // If Value Is Incorrect On If Statement Then Error Is Thrown And Menu Method Restarts
                Console.WriteLine("Error: Please Enter Valid Selection Option Displayed On Menu:");
                Menu();
            }

        }

        private static void IntroMenu()
        {
            // Menu For Initial Program Start (Before Tree Generation)
            //Header Is Generated
            Console.WriteLine("Welecome the BST Enviroment" + "\n");
            for (int lineSep = 0; lineSep < 30; lineSep++)
            {
                Console.Write("--");
            }
            Console.WriteLine("");
            // Intro Menu Navigation Scheme Displayed
            Console.WriteLine("1:Generate Fixed BST");
            Console.WriteLine("2:Generate Random BST");
            Console.WriteLine("3:Generate Fixed Balanced BST");
            Console.WriteLine("4:Generate Degenerate BST");
            Console.WriteLine("5:Build Tree Manually");
            Console.WriteLine("[Q/0]:Exit Program");

            // User Input For Switch Case Actions
            menuInput = Console.ReadLine();
            // User Input To Upper Case To Avoid Input Mismatch
            menuInput = menuInput.ToUpper();
            // If Input Is Integer Or Q  Then Continue With Switch Case Menu
            if (int.TryParse(menuInput, out int value) || menuInput.Equals("Q"))
            {

                //BST tree = new BST();

                switch (menuInput.ToUpper())
                {
                    case "1":
                        //User Generates Hard Coded BST
                        Console.WriteLine("Generating Fixed BST...");
                        Console.WriteLine(menuInput);
                        GenerateFixedTree();

                        break;
                    case "2":
                        // User Randomly Generates BST
                        Console.WriteLine("Generating Random BST...");
                        GenerateRandomBST();
                        break;
                    case "3":
                        // User Generates A Balanced Hard Coded BST
                        Console.WriteLine("Generating Fixed Balanced BST...");
                        FixedBalancedTree();
                        break;
                    case "4":
                        // User Generates A Randomly Generated BST That Is Degenerate
                        Console.WriteLine("Generating Degenerate BST...");
                        DegenerateGeneration();
                        break;
                    case "5":
                        // User Starts Process Of Manually Building Tree Node By Node
                        Console.WriteLine("Generating BST Build Enviroment...");
                        UserTree();

                        break;

                    case "Q":
                    case "0":
                        // User Closes Application
                        Console.WriteLine("Exit BST Enviroment! Goodbye ....");
                        Environment.Exit(1);
                        break;
                    default:
                        // If Switch Case Not Met , Menu Restarts
                        IntroMenu();

                        break;

                }
            }
            else
            {
                // If Statment Conditions Not Met , Intro Menu Restarts
                Console.WriteLine("Error: Please Enter Valid Selection Option Displayed on Menu:");
                IntroMenu();
            }

        }

        private static void DisplayMenu()
        {
            // This Method Is The Visual Display Of Navigation System For Menu() Method
            // Header Line For Console
            for (int lineSep = 0; lineSep < 30; lineSep++)
            {
                Console.Write("--");
            }
            Console.WriteLine("");
            // Display Menu For When Instace Of Tree Class has been created
            Console.WriteLine("1:Display only In Order Values");
            Console.WriteLine("2:Display only Pre Order Values");
            Console.WriteLine("3:Display only Post Order Values");
            Console.WriteLine("4:Display Values In Every Order");
            Console.WriteLine("5:Add Value To Tree");
            Console.WriteLine("6:Delete Value From Tree");
            Console.WriteLine("7:Search for Value Within BST");
            Console.WriteLine("8:Return to Start Menu");
            Console.WriteLine("[Q/0]:Exit Program");
            for (int lineSep = 0; lineSep < 30; lineSep++)
            {
                Console.Write("--");
            }
            Console.WriteLine("");


        }

        public static void RunProgram()
        {
            //Driver Code
            IntroMenu();
            Console.WriteLine("BST Sandbox" + "\n");
            DisplayMenu();

        }


    }


}