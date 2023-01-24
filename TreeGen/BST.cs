using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeGen
{
    public class BST
    {
        static BST tree = new BST();

        public Node Root;
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
                Console.WriteLine("loop");

                if (data == node.leafNumber)
                {
                    Console.WriteLine("User Data:" + data + " Vs " + "Leaf data" + node.leafNumber);
                    Console.WriteLine("Number Found: " + node.leafNumber);
                    return node;
                }
                if (data < node.leafNumber)
                {
                    Console.WriteLine("Smaller than Parent Value go Left side of Tree");
                    Console.WriteLine("User Data:" + data + " Vs " + "Leaf data left side:" + node.leafNumber);
                    //node.leftNode = Test(node.leftNode, data);
                    //Console.WriteLine(node.leafNumber);
                    node.leftNode = SearchBST(node.leftNode, data);



                }
                else
                {
                    Console.WriteLine("Larger than Parant Value go Right side of Tree");
                    Console.WriteLine("User Data:" + data + " Vs " + "Leaf data right side:" + node.leafNumber);

                    node.rightNode = SearchBST(node.rightNode, data);

                }

            }

            if (node == null)
            {
                Console.WriteLine("Node Value Not Found Within tree");
            }


            return null;
        }

        private int MaxValue(Node node)
        {

            if (node.rightNode == null)
            {

                return node.leafNumber;

            }
            return MaxValue(node.rightNode);
        }

        private int MinValue(Node node)
        {
            if (node.leftNode == null)
            {
                return node.leafNumber;
            }
            return (MinValue(node.leftNode));
        }

        private Node AddNode(Node node, int data)
        {
            if (node != null)
            {
                if (data < node.leafNumber)
                {
                    node.leftNode = AddNode(node.leftNode, data);
                }
                else
                {
                    node.rightNode = AddNode(node.rightNode, data);
                }



                return node;
            }

            return new Node(data);
        }

        private static void GenerateRandomBST()

        {
            int treeSizeCounter = 0;
            int i = 0;

            Console.WriteLine("BST Random Generation" + "\n");
            Console.WriteLine("Input BST Node Count (Integer) OR [R] Random Node Count OR [Q] Return To Menu");

            string input = Console.ReadLine();
            input = input.ToUpper();
            if (int.TryParse(input, out int value))
            {

                Console.WriteLine("Generating Tree based On User Chosen Node Count");
                treeSizeCounter = Convert.ToInt32(input);
                if (treeSizeCounter < 0)
                {
                    Console.WriteLine("Error: Please Enter Postive Integer Value! Chosen Node Count Must Be A Postive Value.");
                    GenerateRandomBST();
                }
                Console.WriteLine("Node Count:" + treeSizeCounter);
                treeSizeCounter = treeSizeCounter - 1;

            }
            else if (input.Equals("R"))
            {
                Console.WriteLine("Generating Tree based Random Generated Node Count");
                treeSizeCounter = randomData.Next(1, 100);
                treeSizeCounter = treeSizeCounter - 1;
                Console.WriteLine("Node Count:" + treeSizeCounter);

            }

            else if (input.Equals("Q"))
            {
                Console.WriteLine("Returning To Menu ....");
                RunProgram();

            }

            else
            {
                Console.WriteLine("Error: Incorrect User Input ! Please specify the node count of Random BST By Entering Integer Value['int'] OR Choose Random Node Count ['R'] OR Choose to Quit and retur menu['Q']");
                GenerateRandomBST();

            }
            tree.Root = tree.AddNode(tree.Root, randomData.Next(1, 1000));
            while (i < treeSizeCounter)
            {
                // tree.Root = tree.AddNode(tree.Root, randomData.Next());


                tree.AddNode(tree.Root, randomData.Next(1, 1000));

                i++;

            }




            tree.RandomBSTCompleteDegenTest(tree.Root);





        }


        private Node DegenerateBuild(Node node)
        {
            int degenData = randomData.Next(1, 1000);

            if (degenData > node.leafNumber)
            {
                tree.AddNode(tree.Root, degenData);
            }
            else
            {
                DegenerateBuild(node);
            }
            return node;
        }



        private static void DegenerateGeneration()
        {
            int treeSizeCounter = 0;
            int i = 0;

            Console.WriteLine("BST Random Generation" + "\n");
            Console.WriteLine("Input BST Node Count (Integer) OR [R] Random Node Count OR [Q] Return To Menu");

            string input = Console.ReadLine();
            input = input.ToUpper();
            if (int.TryParse(input, out int value))
            {

                Console.WriteLine("Generating Tree based On User Chosen Node Count");
                treeSizeCounter = Convert.ToInt32(input);
                if (treeSizeCounter < 0)
                {
                    Console.WriteLine("Error: Please Enter Postive Integer Value! Chosen Node Count Must Be A Postive Value.");
                    GenerateRandomBST();
                }
                Console.WriteLine("Node Count:" + treeSizeCounter);
                treeSizeCounter = treeSizeCounter - 1;

            }
            else if (input.Equals("R"))
            {
                Console.WriteLine("Generating Tree based Random Generated Node Count");
                treeSizeCounter = randomData.Next(1, 100);
                treeSizeCounter = treeSizeCounter - 1;
                Console.WriteLine("Node Count:" + treeSizeCounter);

            }

            else if (input.Equals("Q"))
            {
                Console.WriteLine("Returning To Menu ....");
                RunProgram();

            }

            else
            {
                Console.WriteLine("Error: Incorrect User Input ! Please specify the node count of Random BST By Entering Integer Value['int'] OR Choose Random Node Count ['R'] OR Choose to Quit and retur menu['Q']");
                DegenerateGeneration();

            }
            tree.Root = tree.AddNode(tree.Root, randomData.Next(1, 1000));
            while (i < treeSizeCounter)
            {
                // tree.Root = tree.AddNode(tree.Root, randomData.Next());


                tree.DegenerateBuild(tree.Root);

                i++;

            }

            tree.RandomBSTCompleteDegenTest(tree.Root);
        }

        private void PostOrderTraversal(Node node)
        {
            if (node != null)
            {
                this.PostOrderTraversal(node.leftNode);
                this.PostOrderTraversal(node.rightNode);
                Console.Write(node.leafNumber + " ");
            }
            return;


        }

        private void InOrderTraversal(Node node)
        {
            if (node != null)
            {
                this.InOrderTraversal(node.leftNode);
                Console.Write(node.leafNumber + " ");

                this.InOrderTraversal(node.rightNode);


            }
            return;

        }

        private void PreOrderTraversal(Node node)
        {
            if (node != null)
            {
                Console.Write(node.leafNumber + " ");
                this.PreOrderTraversal(node.leftNode);

                this.PreOrderTraversal(node.rightNode);


            }

            return;
        }

        private int MaxDepth(Node node)
        {


            if (node != null)
            {
                int leftDepth = MaxDepth(node.leftNode);
                int rightDepth = MaxDepth(node.rightNode);
                // Console.WriteLine("Right"+rightDepth);
                // Console.WriteLine("left"+leftDepth);

                if (leftDepth > rightDepth)
                {

                    return (leftDepth + 1);
                }

                else
                {

                    return (rightDepth + 1);
                }

            }
            else
            {
                return 0;
            }
        }

        private int NodeCount(Node node)
        {


            if (node != null)
            {
                int leftDepth = NodeCount(node.leftNode);
                int rightDepth = NodeCount(node.rightNode);
                // Console.WriteLine("Right"+rightDepth);
                // Console.WriteLine("left"+leftDepth);

                return leftDepth + rightDepth + 1;

            }
            else
            {
                return 0;
            }
        }

        private static void SearchInput()
        {
            Console.WriteLine("Enter An Integer Value You Wish To Search");
            Console.WriteLine("Exit Enter [Q] ");
            //int newLeafValue = Convert.ToInt32(Console.ReadLine());
            string newLeafValue = Console.ReadLine();
            newLeafValue.ToUpper();
            if (int.TryParse(newLeafValue, out int value))
            {

                Console.WriteLine("Searching For Value In BST... " + newLeafValue);
                tree.SearchBST(tree.Root, Convert.ToInt32(newLeafValue));

            }
            else if (newLeafValue.Equals("Q", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Return To Menu! Goodbye....");
                RunProgram();

            }
            else
            {
                Console.WriteLine("User Input Is Incorrect Type '" + newLeafValue + "'" + "Please Enter An Integer Value");
                SearchInput();
            }

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

        private static void DeleteNodeInput()
        {
            Console.WriteLine("Enter An Integer Value You Wish To Remove");
            Console.WriteLine("Exit Enter [Q] ");
            //int newLeafValue = Convert.ToInt32(Console.ReadLine());
            string LeafValueToBeRemoved = Console.ReadLine();
            LeafValueToBeRemoved.ToUpper();
            if (int.TryParse(LeafValueToBeRemoved, out int value))
            {
                tree.DeleteNode(tree.Root, Convert.ToInt32(LeafValueToBeRemoved));
                DisplayMenu();
                Menu();

            }
            else if (LeafValueToBeRemoved.Equals("Q", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Return To Menu! Goodbye....");
                RunProgram();

            }
            else
            {
                Console.WriteLine("User Input Is Incorrect Type '" + LeafValueToBeRemoved + "'" + "Please Enter An Integer Value");
                DeleteNodeInput();
            }



        }

        private static void InputNode()
        {
            Console.WriteLine("Enter an integer value to add to the BST");
            Console.WriteLine("Exit Enter [Q] ");
            //int newLeafValue = Convert.ToInt32(Console.ReadLine());
            string newLeafValue = Console.ReadLine();
            newLeafValue.ToUpper();
            if (int.TryParse(newLeafValue, out int value))
            {

                Console.WriteLine("Adding new leaf value... " + newLeafValue);
                tree.AddNode(tree.Root, Convert.ToInt32(newLeafValue));
                Console.WriteLine("In order ");
                tree.InOrderTraversal(tree.Root);

            }
            else if (newLeafValue.Equals("Q", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Return To Menu! Goodbye....");
                RunProgram();

            }
            else
            {
                Console.WriteLine("User Input Is incorrect type '" + newLeafValue + "'" + "please enter an integer value");
                InputNode();
            }

        }

        private static void Menu()
        {
            Console.WriteLine("");
            Console.WriteLine("BST Stats: " + "Tree Depth:" + tree.MaxDepth(tree.Root) + "|Tree Node Count:" + tree.NodeCount(tree.Root) + "|Max BST Node Value:" + tree.MaxValue(tree.Root) + "|Min BST Node Value:" + tree.MinValue(tree.Root) + "|BST Root Value:" + tree.Root.leafNumber
                );
            string menuInput = "";
            menuInput = Console.ReadLine();
            menuInput = menuInput.ToUpper();
            if (int.TryParse(menuInput, out int value) || menuInput.Equals("Q"))
            {

                //BST tree = new BST();

                switch (menuInput.ToUpper())
                {

                    case "1":
                        DisplayMenu();
                        Console.WriteLine("In order ");
                        tree.InOrderTraversal(tree.Root);
                        Menu();

                        break;
                    case "2":
                        DisplayMenu();
                        Console.WriteLine("Pre order ");
                        tree.PreOrderTraversal(tree.Root);
                        Menu();
                        break;
                    case "3":
                        DisplayMenu();
                        Console.WriteLine("Post Order");
                        tree.PostOrderTraversal(tree.Root);
                        Menu();
                        break;
                    case "4":
                        DisplayMenu();
                        Console.WriteLine("");
                        Console.WriteLine("In order ");
                        tree.InOrderTraversal(tree.Root);
                        Console.WriteLine("");
                        Console.WriteLine("Pre order ");
                        tree.PreOrderTraversal(tree.Root);
                        Console.WriteLine("");
                        Console.WriteLine("Post Order");
                        tree.PostOrderTraversal(tree.Root);
                        Menu();
                        break;
                    case "5":
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
                        DisplayMenu();
                        Console.WriteLine("");
                        Console.WriteLine("Delete Value From Tree");
                        Console.WriteLine("");
                        Console.Write("Current Tree Values:");
                        tree.InOrderTraversal(tree.Root);
                        DeleteNodeInput();
                        break;
                    case "7":
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
                        DisplayMenu();
                        Console.WriteLine("Returning To Start menu ....");
                        RunProgram();

                        break;
                    case "Q":
                    case "0":
                        Console.WriteLine("Exit BST Enviroment! Goodbye ....");
                        Environment.Exit(1);
                        break;
                    default:
                        Menu();

                        break;

                }
            }
            else
            {
                Console.WriteLine("Please Enter Valid Selection Option Displayed on Menu:");
                Menu();
            }

        }

        private static void GenerateFixedTree()
        {
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
        }

        private static void ConstructRoot()
        {
            Console.WriteLine("BST User Creation" + "\n");
            Console.WriteLine("Input BST Root Value(Integer) OR [Q] Return To Menu");
            string userInput = Console.ReadLine();
            userInput = userInput.ToUpper();
            if (int.TryParse(userInput, out int value))
            {

                tree.Root = tree.AddNode(tree.Root, Convert.ToInt32(userInput));
                Console.WriteLine("Your Custom Tree Root Value:" + tree.Root.leafNumber);
                Console.WriteLine("\n" + "Please Enter Value To Be Contained In The New Node");

            }
            else if (userInput.Equals("Q"))
            {
                Console.WriteLine("Returning To Menu...");
                RunProgram();
            }
            else
            {
                Console.WriteLine("Error: Incorrect Value ! Please Enter Integer Value to Construct Root.");
                ConstructRoot();

            }

        }

        private static void ConstructNodes()
        {
            Console.WriteLine("BST User Creation");
            int run = 1;//Console.ReadLine();
                        //userInput = userInput.ToUpper();


            while (run == 1)
            {
                Console.WriteLine("Input BST Node Value(Integer) OR [F] To Generate Finished Tree OR [Q] Return To Menu");
                String userInput = Console.ReadLine();
                userInput = userInput.ToUpper();

                if (int.TryParse(userInput, out int value1))
                {


                    tree.AddNode(tree.Root, Convert.ToInt32(userInput));
                    //userInput = Console.ReadLine();
                    //userInput = userInput.ToUpper();
                    Console.WriteLine("Your Custom Node Value:" + tree.Root.leafNumber);
                    if (tree.Root.leftNode == null && tree.Root.rightNode == null)
                    {
                        Console.WriteLine("Your Custom Tree Root Value:" + tree.Root.leafNumber);
                        Console.WriteLine("BST Stats: " + "Tree Depth:" + tree.MaxDepth(tree.Root) + "|Tree Node Count:" + tree.NodeCount(tree.Root) + "|Max BST Node Value:" + tree.MaxValue(tree.Root) + "|Min BST Node Value:" + tree.MinValue(tree.Root));
                        Console.WriteLine("\n" + "Please Enter Value To Be Contained In The New Node");
                        Console.WriteLine("");

                    }
                    else
                    {
                        Console.WriteLine("Your Custom last Custom Node Value:" + tree.Root.leafNumber);
                        Console.WriteLine("BST Stats: " + "Tree Depth:" + tree.MaxDepth(tree.Root) + "|Tree Node Count:" + tree.NodeCount(tree.Root) + "|Max BST Node Value:" + tree.MaxValue(tree.Root) + "|Min BST Node Value:" + tree.MinValue(tree.Root));
                        Console.WriteLine("\n" + "Please Enter Value To Be Contained In The New Node");
                        Console.WriteLine("");


                    }






                }

                else if (userInput.Equals("Q"))
                {
                    Console.WriteLine("Returning To Menu...");
                    RunProgram();
                }

                else if (userInput.Equals("F"))
                {
                    tree.UserBSTCompleteDegenTest(tree.Root);
                    DisplayMenu();
                    Menu();
                }
                else
                {
                    Console.WriteLine("Error: Incorrect Value ! Please Enter Integer Value to Construct Node.");
                    ConstructNodes();
                }





            }

        }

        private void UserBSTCompleteDegenTest(Node node)
        {
            if (node != null)
            {
                if (Root.leftNode == null && Root.rightNode == null)
                {
                    return;

                }
                else if (Root.leftNode == null || Root.rightNode == null)
                {
                    Console.WriteLine(" Warning: You will generate a Complete Degenerate BST!");
                    Console.WriteLine("Are you sure you want to continue to generate this tree? [Y]es Continue: |  [R]estart: | [N]o: Return To Menu ");
                    string input = Console.ReadLine();
                    input = input.ToUpper();

                    if (input.Equals("Y"))
                    {
                        Console.WriteLine("Generating Custom BST ....");


                    }
                    else if (input.Equals("R"))
                    {
                        Console.WriteLine("Restarting Tree Construction...");
                        UserTree();
                    }
                    else if (input.Equals("N"))
                    {
                        Console.WriteLine("Returning To Menu...");
                        RunProgram();
                    }
                    else
                    {
                        Console.WriteLine("Error: Incorrect Input Please Enter [Y]es Continue: |  [R]estart: | [Q]uit: Return");
                        tree.UserBSTCompleteDegenTest(tree.Root);
                    }

                }



            }

            return;

        }

        private void RandomBSTCompleteDegenTest(Node node)
        {
            if (node != null)
            {
                if (Root.leftNode == null && Root.rightNode == null)
                {
                    return;

                }
                else if (Root.leftNode == null || Root.rightNode == null)
                {
                    Console.WriteLine(" Warning: You will generate a Complete Degenerate BST!");
                    Console.WriteLine("Are you sure you want to continue to generate this tree? [Y]es Continue: |  [R]estart: | [N]o: Return To Menu ");
                    string input = Console.ReadLine();
                    input = input.ToUpper();

                    if (input.Equals("Y"))
                    {
                        Console.WriteLine("Generating Random BST ....");


                    }
                    else if (input.Equals("R"))
                    {
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
                        Console.WriteLine("Error: Incorrect Input Please Enter [Y]es Continue: |  [R]estart: | [Q]uit: Return");
                        tree.UserBSTCompleteDegenTest(tree.Root);
                    }

                }



            }

            return;

        }

        private static void UserTree()
        {
            ConstructRoot();
            ConstructNodes();









        }

        private static void IntroMenu()
        {
            Console.WriteLine("Welecome the BST Enviroment" + "\n");
            for (int lineSep = 0; lineSep < 30; lineSep++)
            {
                Console.Write("--");
            }
            Console.WriteLine("");

            Console.WriteLine("1:Generate Fixed BST Finished(Functional)");
            Console.WriteLine("2:Generate Random BST(Functional)");
            Console.WriteLine("3:Generate Balanced BST(NOT Functional)");
            Console.WriteLine("4:Generate Degenerate BST(Functional)");
            Console.WriteLine("5:Build Tree Manually(Functional)");
            Console.WriteLine("[Q/0]:Exit Program");


            menuInput = Console.ReadLine();
            menuInput = menuInput.ToUpper();
            if (int.TryParse(menuInput, out int value) || menuInput.Equals("Q"))
            {

                //BST tree = new BST();

                switch (menuInput.ToUpper())
                {
                    case "1":
                        Console.WriteLine("Generating Fixed BST...");
                        Console.WriteLine(menuInput);
                        GenerateFixedTree();

                        break;
                    case "2":
                        Console.WriteLine("Generating Random BST...");
                        GenerateRandomBST();

                        break;
                    case "3":
                        Console.WriteLine("Generating Balanced BST...");
                        break;
                    case "4":
                        Console.WriteLine("Generating Degenerate BST...");
                        DegenerateGeneration();
                        break;
                    case "5":
                        Console.WriteLine("Generating BST Build Enviroment...");
                        UserTree();

                        break;

                    case "Q":
                    case "0":
                        Console.WriteLine("Exit BST Enviroment! Goodbye ....");
                        Environment.Exit(1);
                        break;
                    default:
                        IntroMenu();

                        break;

                }
            }
            else
            {
                Console.WriteLine("Please Enter Valid Selection Option Displayed on Menu:");
                IntroMenu();
            }

        }

        private static void DisplayMenu()
        {

            for (int lineSep = 0; lineSep < 30; lineSep++)
            {
                Console.Write("--");
            }
            Console.WriteLine("");

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
            IntroMenu();
            Console.WriteLine("BST Sandbox" + "\n");
            DisplayMenu();
            Menu();
        }
    }
}
