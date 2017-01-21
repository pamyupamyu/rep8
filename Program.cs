﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class program
    {
        static void Main(string[] args)
        {
            (new Planning()).startplanning();
        }
    }

    class common

    {

        public static void printlist(List<string> list)

        {

            for (int i = 0; i < list.Count; i++)

            {

                // Debug.Log(list[i]);

            }

        }



        //tokenazer使っているものがあっている保証はない

        public static List<string> getVars(string thePattern, List<string> vars)

        {

            string[] token = thePattern.Split();

            for (int i = 0; i < token.Length; i++)

            {

                if (var(token[i]))

                {

                    vars.Add(token[i]);

                }

            }

            return vars;

        }



        public static bool var(string str)

        {

            return str.StartsWith("?");

        }



    }
   class Planning

    {
        // public GameObject Init, Goal;
        //private Text InitText, GoalText;

        //オペレーターを囲うリスト

        List<Operator> operators;

        Random rand;

        //planも同じくオペレーター

        List<Operator> plan;

        //goalと同じくstring型

        List<string> finalgoal;

        List<Items> items = new List<Items>();

        public Planning()

        {

            //乱数にて行う

            rand = new Random();

        }

        public List<string> goalsort(List<string> goalList)

        {
            Console.WriteLine("check1");
            List<string> newgoal = new List<string>();

            List<string> ontable = new List<string>();

            List<string> xony = new List<string>();

            List<string> clear = new List<string>();

            List<string> handEmpty = new List<string>();

            List<string> holding = new List<string>();

            List<string> poada = new List<string>();



            for (int i = 0; i < goalList.Count; ++i)

            {
                string[] st = goalList[i].Split();
                string tmp = st[0];

                if (goalList[i].Contains("ontable"))

                {

                    ontable.Add(goalList[i]);
                    poada.Add(st[1]);
                    //nextTokenをpoadaに入れる

                }

                else if (goalList[i].Contains("clear"))

                {

                    clear.Add(goalList[i]);

                }

                else if (goalList[i].Contains("handEmpty"))

                {

                    handEmpty.Add(goalList[i]);

                }

                else

                {

                    xony.Add(goalList[i]);

                }



            }

            for (int i = 0; i < ontable.Count; ++i)

            {

                newgoal.Add(ontable[i]);

            }

            // xony sort
            xony = XonYsort(xony, poada);
            for (int i = 0; i < xony.Count; ++i)

            {

                newgoal.Add(xony[i]);

            }

            for (int i = 0; i < clear.Count; ++i)

            {

                newgoal.Add(clear[i]);

            }

            for (int i = 0; i < holding.Count; ++i)
            {
                newgoal.Add(holding[i]);
            }

            for (int i = 0; i < handEmpty.Count; ++i)

            {

                newgoal.Add(handEmpty[i]);

            }


            Console.WriteLine("check2");


            return newgoal;

        }



        //未定　xony sort

        public List<string> XonYsort(List<string> xony, List<string> poada)

        {

            List<string> newxony = new List<string>();

            for (int i = 0; i < poada.Count; ++i)
            {
                for (int j = 0; j < xony.Count; ++j)
                {
                    string[] st = xony[j].Split();
                    string X = st[0];
                    string Y = st[2];

                    if (poada[i].Equals(Y))
                    {
                        newxony.Add(xony[j]);
                        //これやばい
                        poada[i] = X;
                        //poada.Insert(i, X);
                        j = -1;
                    }
                }

            }
            return newxony;

        }


        public string search(string s)
        {
            string answer = null;
            for (int i = 0; i < items.Count; ++i)
            {
                Items I = items[i];
                if (I.name.Equals(s) || I.color.Equals(s) || I.shape.Equals(s))
                {
                    answer = I.name;
                }
            }
            return answer;
        }

        public void instatiate(List<string> inList, List<string> List)
        {
            for (int i = 0; i < List.Count; ++i)
            {
                string[] st = List[i].Split();
                string tmp = st[0];
                string s;
                if (tmp.Equals("ontable"))
                {
                    s = st[1];
                    inList.Insert(i, "ontable " + search(s));
                    //System.out.println(inList.get(i));
                }
                else if (tmp.Equals("clear"))
                {
                    s = st[1];
                    inList.Insert(i, "clear " + search(s));
                    //System.out.println(inList.get(i));
                }
                else if (tmp.Equals("handEmpty"))
                {
                    inList.Insert(i, "handEmpty");
                    //System.out.println(inList.get(i));
                }
                else if (tmp.Equals("holding"))
                {
                    s = st[1];
                    inList.Insert(i, "holding " + search(s));
                }
                else
                {
                    string tmp2 = search(tmp);
                    s = st[1]; //on
                    s = st[2];
                    inList.Insert(i, tmp2 + " on " + search(s));
                    //System.out.println(inList.get(i));
                }
            }
        }


        //変更 返り値:void → List<string>
        public List<string> startplanning()

        {

            initOperators(); //operatorのセット
            initItems();

            List<string> planList = new List<string>();

            List<string> goalList = initGoalList(); //goalのセット

            List<string> initialState = initInitialState(); //startのセット

            List<string> ingoal = new List<string>();

            instatiate(ingoal, goalList);
            finalgoal = new List<string>(ingoal);
            //finalgoal = ingoal;
            List<string> inState = new List<string>();
            instatiate(inState, initialState);
            ingoal = goalsort(ingoal);


            //goalsortなど追加機能は後回し

            //goalList = goalsort(goalList);

            //Console.WriteLine(goalList);

            //束縛変数

            Hashtable theBinding = new Hashtable();

            plan = new List<Operator>();
            //修正
            planning(ingoal, inState, theBinding); //plannig 実行



            //終了

            Console.WriteLine("**** This is a plan!****");

            //Console.WriteLine("This is a plan");

            for (int i = 0; i < plan.Count; i++)

            {

                Operator op = plan[i];

                Console.WriteLine((op.instantiate(theBinding)).name);
                planList.Add((op.instantiate(theBinding)).name);
                //Console.WriteLine((op.instantiate(theBinding)).name);

            }
            return planList;

        }



        bool planning(List<string> theGoalList, List<string> theCurrentState, Hashtable theBinding)

        {



            //var check = Console.ReadLine();



            for (int count = 0; count < 100; count++)

            {

                Console.WriteLine("***目標状態***");

                Console.WriteLine("ゴールの先頭" + theGoalList[0]);//goallistの表示

                //Console.WriteLine("ゴールリスト");

                //Console.WriteLine("ゴールの先頭" + theGoalList[0]);



                if (theGoalList.Count == 1) //goalが一つの時

                {

                    string aGoal = theGoalList[0];

                    if (planningAGoal(aGoal, theCurrentState, theBinding, 0) != -1)

                    {

                        return true;

                    }

                    else

                    {

                        return false;

                    }

                }

                else

                {

                    string aGoal = theGoalList[0];

                    int cPoint = 0;

                    while (cPoint < operators.Count)

                    {

                        Hashtable orgBinding = new Hashtable();

                        foreach (string key in theBinding.Keys)

                        {

                            orgBinding.Add((string)key, (string)theBinding[key]);

                        }

                        List<string> orgState = new List<string>();

                        for (int i = 0; i < theCurrentState.Count; i++)

                        {

                            orgState.Add(theCurrentState[i]);

                        }

                        int tmpPoint = planningAGoal(aGoal, theCurrentState, theBinding, cPoint);

                        if (tmpPoint != -1)

                        {

                            theGoalList.RemoveAt(0);

                            //current

                            //common.printlist(theCurrentState);

                            if (planning(theGoalList, theCurrentState, theBinding))

                            {

                                return true;

                            }

                            else

                            {

                                cPoint = tmpPoint;

                                //挿入

                                theGoalList.Insert(0, aGoal);

                                //ハッシュを空にする

                                theBinding.Clear();

                                foreach (string key in orgBinding.Keys)

                                {

                                    theBinding.Add((string)key, (string)orgBinding[key]);

                                }

                                theCurrentState.Clear();

                                for (int i = 0; i < orgState.Count; i++)

                                {

                                    theCurrentState.Add(orgState[i]);

                                }

                            }

                        }

                        else

                        {

                            theBinding.Clear();

                            foreach (string key in orgBinding.Keys)

                            {

                                theBinding.Add(key, (string)orgBinding[key]);

                            }

                            theCurrentState.Clear();

                            for (int i = 0; i < orgState.Count; i++)

                            {

                                theCurrentState.Add(orgState[i]);

                            }

                            return false;

                        }

                    }

                    return false;

                }

            }

            return false;

        }





        int planningAGoal(string theGoal, List<string> theCurrentState, Hashtable theBinding, int cPoint)

        {

            Console.WriteLine("**Agoal開始**" + theGoal);

            //Console.WriteLine("Agoal開始" + theGoal);

            int size = theCurrentState.Count;

            for (int i = 0; i < size; i++)

            {

                string aState = theCurrentState[i];

                if ((new Unifier()).unify(theGoal, aState, theBinding))

                {

                    return 0;

                }

            }

            //競合で数字選ぶところ

            int index = ConflictResolution(theGoal, theCurrentState);

            Operator op = operators[index];

            //Console.WriteLine("index : " + index);

            operators.RemoveAt(index);

            operators.Insert(0, op);

            //乱数を用いるとUnityが落ちる　意味不明なバグがある



            for (int i = cPoint; i < operators.Count; i++)

            {

                //一つのオペレーターの生成

                //Console.WriteLine("**check4**");

                /*ここ****************************************************/

                Operator anOperator = rename(operators[i]);

                Hashtable orgBinding = new Hashtable();

                //Console.WriteLine("**check6**");

                foreach (string key in theBinding.Keys)

                {

                    orgBinding.Add(key, (string)theBinding[key]);

                }

                List<string> orgState = new List<string>();

                for (int j = 0; j < theCurrentState.Count; j++)

                {

                    orgState.Add(theCurrentState[j]);

                }

                List<Operator> orgPlan = new List<Operator>();

                for (int j = 0; j < plan.Count; j++)

                {

                    orgPlan.Add(plan[j]);

                }

                //addListの生成

                List<string> addList = anOperator.getAddList();

                for (int j = 0; j < addList.Count; j++)

                {

                    if ((new Unifier()).unify(theGoal, addList[j], theBinding))

                    {

                        Operator newOperator = anOperator.instantiate(theBinding);



                        List<string> newGoals = newOperator.getIfList();

                        //Console.WriteLine(newOperator.name);

                        //       Console.WriteLine(newOperator.name); //動作不明

                        if (planning(newGoals, theCurrentState, theBinding))

                        {

                            //Console.WriteLine(newOperator.name);

                            //以下　更新可能かどうかのチェックが入る

                            //成功したら更新、失敗したら復元を行う

                            if (newOperator.applyStatecheck(theCurrentState, theBinding))

                            {  //正常

                                plan.Add(newOperator);

                                theCurrentState = newOperator.applyState(theCurrentState, theBinding);

                                //common.printlist(theCurrentState);

                                return i + 1;

                            }

                            else

                            {  //失敗

                                theBinding.Clear();

                                foreach (string key in orgBinding.Keys)

                                {

                                    theBinding.Add(key, (string)orgBinding[key]);

                                }

                                theCurrentState.Clear();

                                for (int k = 0; k < orgState.Count; k++)

                                {

                                    theCurrentState.Add(orgState[k]);

                                }



                                plan.Clear();

                                for (int k = 0; k < orgPlan.Count; k++)

                                {

                                    plan.Add(orgPlan[k]);

                                }

                            }

                            //以上　追加

                        }

                        else

                        {

                            theBinding.Clear();

                            foreach (string key in orgBinding.Keys)

                            {

                                theBinding.Add(key, (string)orgBinding[key]);

                            }

                            theCurrentState.Clear();

                            for (int k = 0; k < orgState.Count; k++)

                            {

                                theCurrentState.Add(orgState[k]);

                            }

                            plan.Clear();

                            for (int k = 0; k < orgPlan.Count; k++)

                            {

                                plan.Add(orgPlan[k]);

                            }

                        }

                    }

                }

            }

            return -1;

        }



        //競合解決

        int ConflictResolution(string theGoal, List<string> theCurrentState)

        {

            string[] goal = theGoal.Split(); //??

            int[] cost = new int[operators.Count];

            bool mflag;

            for (int i = 0; i < operators.Count; i++)

            {

                Operator anOperator = operators[i];

                List<string> addlist = anOperator.getAddList();

                List<string> iflist = anOperator.getIfList();

                List<string> addList = new List<string>(); //なにこれ？

                for (int j = 0; j < addlist.Count; ++j)

                {

                    addList.Add(addlist[j]);

                }

                List<string> ifList = new List<string>();

                for (int j = 0; j < iflist.Count; ++j)

                {

                    ifList.Add(iflist[j]);

                }

                mflag = false;

                for (int j = 0; j < addList.Count; ++j)

                {

                    string[] str = addList[j].Split(); //分割

                    if (str.Length == goal.Length)

                    {

                        if (goal.Length == 3)

                        {

                            int if_size = ifList.Count;

                            for (int k = 0; k < if_size; ++k)

                            {

                                //ここが無限ループ

                                string[] s = ifList[k].Split();

                                if (s[1].Equals("?x"))

                                {

                                    s[1] = goal[0];

                                }

                                else if (s[1].Equals("?y"))

                                {

                                    s[1] = goal[2];

                                }

                                string buf = "";

                                buf += s[0];

                                for (int l = 1; l < s.Length; ++l)

                                {

                                    buf = buf + " " + s[l];

                                }

                                ifList.Insert(k, buf);

                                //ifListに追加したら長引くのでは？

                            }

                            mflag = true;

                        }

                        else if (goal.Length == 2)

                        {

                            if (goal[0].Equals(str[0]))

                            {

                                int if_size = ifList.Count;

                                for (int k = 0; k < if_size; ++k)

                                {

                                    string[] s = ifList[k].Split();

                                    if (s.Length == 3)

                                    {

                                        if (str[1] == "?x") s[0] = goal[1];

                                        else s[2] = goal[1];

                                    }

                                    else if (s.Length == 2)

                                    {

                                        if (s[1].Equals(str[1])) s[1] = goal[1];

                                    }

                                    string buf = "";

                                    buf += s[0];

                                    for (int l = 1; l < s.Length; ++l)

                                    {

                                        buf = buf + " " + s[l];

                                    }

                                    ifList.Insert(k, buf);

                                }

                                mflag = true;

                            }

                        }

                    }

                    else if (goal.Length == 1)

                    {

                        mflag = true;

                    }

                }

                Hashtable bind = new Hashtable();

                if (mflag)

                {

                    for (int j = 0; j < ifList.Count; ++j)

                    {

                        int size = theCurrentState.Count;

                        for (int k = 0; k < size; ++k)

                        {

                            string aState = theCurrentState[k];

                            if ((new Unifier()).unify(ifList[j], aState, bind))

                            {

                                cost[i] += 1;

                            }

                        }

                    }

                    bind.Clear();

                }

            }

            int index = 0;

            int max = cost[0];

            for (int i = 1; i < cost.Length; ++i)

            {

                if (cost[i] >= max)

                {

                    index = i;

                    max = cost[i];

                }

            }

            if (goal[0].Equals("handEmpty"))

            {

                string[] hold = theCurrentState[theCurrentState.Count - 1].Split();

                for (int i = 0; i < finalgoal.Count; ++i)

                {

                    string[] fg = finalgoal[i].Split();

                    if (fg.Length == 3)

                    {

                        if (fg[0] == hold[1] && theCurrentState.Contains("clear " + fg[2]))

                        {

                            return index;

                        }

                    }

                }

                cost[index] -= -5;

                index = 0;

                max = cost[0];

                for (int i = 1; i < cost.Length; ++i)

                {

                    if (cost[i] >= max)

                    {

                        index = i;

                        max = cost[i];

                    }

                }

            }

            return index;

        }

        //変数用のユニークな変数

        int uniqueNum = 0;

        private Operator rename(Operator theOperator)

        {

            Operator newOperator = theOperator.getRenamedOperator(uniqueNum);

            uniqueNum = uniqueNum + 1;

            return newOperator;

        }



        //動的変更できるようにする
        
        public List<string> initGoalList()

        {
            //GoalText = Goal.GetComponent<Text>();

            List<string> goalList = new List<string>();

            //print(GoalText.text);

            goalList.Add("ontable C");

            goalList.Add("B on C");

            goalList.Add("A on B");

            goalList.Add("clear A");

            goalList.Add("handEmpty");

            finalgoal = goalList; //copy

            return goalList;

        }
        


        //動的変更できるようにする

        public List<string> initInitialState()

        {

            List<string> initialState = new List<string>();

            //initialState.Add("ontable A");
            initialState.Add("clear A");

            initialState.Add("clear C");

            initialState.Add("A on B");

            initialState.Add("ontable B");

            initialState.Add("ontable C");
            //initialState.Add("clear B");            

            initialState.Add("handEmpty");

            return initialState;

        }

        //オペレーターセット

        public void initOperators()

        {

            //Vectorに代替するものがわからん

            operators = new List<Operator>();



            string name1 = "Place ?x on ?y";

            List<string> ifList1 = new List<string>();

            ifList1.Add("clear ?y");

            ifList1.Add("holding ?x");

            List<string> addList1 = new List<string>();

            addList1.Add("?x on ?y");

            addList1.Add("clear ?x");

            addList1.Add("handEmpty");

            List<string> deleteList1 = new List<string>();

            deleteList1.Add("clear ?y");

            deleteList1.Add("holding ?x");

            Operator operator1 = new Operator(name1, ifList1, addList1, deleteList1);

            operators.Add(operator1);



            string name2 = "remove ?x from on top ?y";

            List<string> ifList2 = new List<string>();

            ifList2.Add("?x on ?y");

            ifList2.Add("clear ?x");

            ifList2.Add("handEmpty");

            List<string> addList2 = new List<string>();

            addList2.Add("clear ?y");

            addList2.Add("holding ?x");

            List<string> deleteList2 = new List<string>();

            deleteList2.Add("?x on ?y");

            deleteList2.Add("clear ?x");

            deleteList2.Add("handEmpty");

            Operator operator2 = new Operator(name2, ifList2, addList2, deleteList2);

            operators.Add(operator2);



            string name3 = "pick up ?x from the table";

            List<string> ifList3 = new List<string>();

            ifList3.Add("ontable ?x");

            ifList3.Add("clear ?x");

            ifList3.Add("handEmpty");

            List<string> addList3 = new List<string>();

            addList3.Add("holding ?x");

            List<string> deleteList3 = new List<string>();

            deleteList3.Add("ontable ?x");

            deleteList3.Add("clear ?x");

            deleteList3.Add("handEmpty");

            Operator operator3 = new Operator(name3, ifList3, addList3, deleteList3);

            operators.Add(operator3);



            string name4 = "put ?x down on the table";

            List<string> ifList4 = new List<string>();

            ifList4.Add("holding ?x");

            List<string> addList4 = new List<string>();

            addList4.Add("ontable ?x");

            addList4.Add("clear ?x");

            addList4.Add("handEmpty");

            List<string> deleteList4 = new List<string>();

            deleteList4.Add("holding ?x");

            Operator operator4 = new Operator(name4, ifList4, addList4, deleteList4);

            operators.Add(operator4);



        }

        class Items
        {
            public string name;
            public string color;
            public string shape;

            public Items(string theName, string thecolor, string theshape)
            {
                name = theName;
                color = thecolor;
                shape = theshape;
            }
        }

        void initItems()
        {

            string name1 = "A";
            string color1 = "blue";
            string shape1 = "cube";
            Items items1 = new Items(name1, color1, shape1);
            items.Add(items1);

            string name2 = "B";
            string color2 = "yellow";
            string shape2 = "tri";
            Items items2 = new Items(name2, color2, shape2);
            items.Add(items2);

            string name3 = "C";
            string color3 = "red";
            string shape3 = "cube";
            Items items3 = new Items(name3, color3, shape3);
            items.Add(items3);

        }

        //開始



      


    }







    //Operatorクラス

    class Operator

    {

        public string name;

        List<string> ifList;

        List<string> addList;

        List<string> deleteList;

        //修正 publicに変更

        public Operator(string theName, List<string> theIfList, List<string> theAddList, List<string> theDeleteList)

        {

            name = theName;

            ifList = theIfList;

            addList = theAddList;

            deleteList = theDeleteList;

        }



        public List<string> getAddList()

        {

            return addList;

        }

        public List<string> getDeleteList()

        {

            return deleteList;

        }

        public List<string> getIfList()

        {

            return ifList;

        }

        public string toString()

        {

            string result =

                "NAME: " + name + "\n" +

                "IF :" + ifList + "\n" +

                "ADD:" + addList + "\n" +

                "DELETE:" + deleteList;

            return result;

        }



        //現在状態を更新可能か調べる

        public bool applyStatecheck(List<string> theState, Hashtable theBinding)

        {

            List<string> checkState = theState; //cloneがこれと同等かは分からん

            for (int i = 0; i < addList.Count; i++)

            { //??

                if (checkState.Contains(instantiateString(addList[i], theBinding))) return false;

            }

            for (int i = 0; i < deleteList.Count; i++)

            {

                if (!checkState.Contains(instantiateString(deleteList[i], theBinding))) return false;

            }

            return true;

        }



        public List<string> applyState(List<string> theState, Hashtable theBinding)

        {

            for (int i = 0; i < addList.Count; i++)

            {

                //現在状態に追加するとき変数の具体化を行う

                theState.Add(instantiateString(addList[i], theBinding));

            }

            for (int i = 0; i < deleteList.Count; i++)

            {

                //現在状態から削除するとき変数の具体化を行う

                theState.Remove(instantiateString(deleteList[i], theBinding));

            }

            return theState;

        }



        public Operator getRenamedOperator(int uniqueNum)

        {

            List<string> vars = new List<string>();

            for (int i = 0; i < ifList.Count; i++)

            {

                string anIf = ifList[i];

                vars = common.getVars(anIf, vars);

            }

            for (int i = 0; i < addList.Count; i++)

            {

                string anAdd = addList[i];

                vars = common.getVars(anAdd, vars);

            }

            for (int i = 0; i < deleteList.Count; i++)

            {

                string aDelete = deleteList[i];

                vars = common.getVars(aDelete, vars);

            }

            Hashtable renamedVarsTable = makeRenamedVarsTable(vars, uniqueNum);



            //新If,Add,Deleteリスト,nameを作る

            List<string> newIfList = new List<string>();

            for (int i = 0; i < ifList.Count; i++)

            {

                string newAnIf = renameVars(ifList[i], renamedVarsTable);

                newIfList.Add(newAnIf);

            }

            List<string> newAddList = new List<string>();

            for (int i = 0; i < addList.Count; i++)

            {

                string newAnAdd = renameVars(addList[i], renamedVarsTable);

                newAddList.Add(newAnAdd);

            }

            List<string> newDeleteList = new List<string>();

            for (int i = 0; i < deleteList.Count; i++)

            {

                string newADelete = renameVars(deleteList[i], renamedVarsTable);

                newDeleteList.Add(newADelete);

            }

            string newName = renameVars(name, renamedVarsTable);

            //新たなオペレーターを返す

            return new Operator(newName, newIfList, newAddList, newDeleteList);

        }



        private Hashtable makeRenamedVarsTable(List<string> vars, int uniqueNum)

        {

            Hashtable result = new Hashtable();

            //Console.WriteLine("vars.Count = "+vars.Count);

            for (int i = 0; i < vars.Count; i++)

            {

                string newVar = vars[i] + uniqueNum;

                //バグ　カギの重複

                result[vars[i]] = newVar;

                //result.Add(vars[i],newVar);



            }

            return result;

        }



        private string renameVars(string thePattern, Hashtable renamedVarsTable)

        {

            string result = "";

            string[] st = thePattern.Split();

            for (int i = 0; i < st.Length; i++)

            {

                if (common.var(st[i]))

                {

                    //string val = (string)renamedVarsTable[st[i]]; st[i]がkeyのものを探す

                    result = result + " " + (string)renamedVarsTable[st[i]];

                }

                else

                {

                    result = result + " " + st[i];

                }

            }

            //trim あってるかは知らん

            return result.Trim();

        }

        public Operator instantiate(Hashtable theBinding)

        {

            string newName = instantiateString(name, theBinding);

            //ifListの具体化

            List<string> newIfList = new List<string>();

            for (int i = 0; i < ifList.Count; i++)

            {

                string newIf = instantiateString(ifList[i], theBinding);

                newIfList.Add(newIf);

            }

            //addListの具体化

            List<string> newAddList = new List<string>();

            for (int i = 0; i < addList.Count; i++)

            {

                string newAdd = instantiateString(addList[i], theBinding);

                newAddList.Add(newAdd);

            }

            //deleteListの具体化

            List<string> newDeleteList = new List<string>();

            for (int i = 0; i < deleteList.Count; i++)

            {

                string newDelete = instantiateString(deleteList[i], theBinding);

                newDeleteList.Add(newDelete);

            }

            return new Operator(newName, newIfList, newAddList, newDeleteList);

        }





        private string instantiateString(string thePattern, Hashtable theBinding)

        {

            string result = "";

            string[] st = thePattern.Split();

            for (int i = 0; i < st.Length; i++)

            {

                if (common.var(st[i]))

                {

                    string newString = (string)theBinding[st[i]];

                    //変更　あってるかは分からん

                    if (newString == null || newString.Length == 0)

                    {

                        result = result + " " + st[i];

                    }

                    else

                    {

                        result = result + " " + newString;

                    }

                }

                else

                {

                    result = result + " " + st[i];

                }

            }

            return result.Trim();

        }



    }



    //Unifyクラス

    class Unifier

    {

        //stringtokenizerの代用を考える

        string[] st1;

        string[] buffer1;

        string[] st2;

        string[] buffer2;

        Hashtable vars = new Hashtable();



        //publicに変更

        public Unifier()

        {



        }



        public bool unify(string string1, string string2, Hashtable theBindings)

        {

            Hashtable orgBindings = new Hashtable();

            foreach (string key in theBindings.Keys)

            {

                orgBindings.Add(key, (string)theBindings[key]);

            }



            this.vars = theBindings;

            if (unify(string1, string2))

            {

                return true;

            }

            else

            {

                theBindings.Clear();

                foreach (string key in orgBindings.Keys)

                {

                    theBindings.Add(key, (string)orgBindings[key]);

                }

                return false;

            }

        }



        public bool unify(string string1, string string2)

        {

            if (string1.Equals(string2)) return true;



            //stringtokenazer代わり

            st1 = string1.Split();

            st2 = string2.Split();



            //数が違うなら失敗

            if (st1.Length != st2.Length) return false;

            //定数同士

            int length = st1.Length;

            buffer1 = new string[length];

            buffer2 = new string[length];

            for (int i = 0; i < length; i++)

            {

                buffer1[i] = st1[i];

                buffer2[i] = st2[i];

            }



            //初期値としてBindingが与えられているとき

            if (this.vars.Count != 0)

            {

                foreach (string key in vars.Keys)

                {

                    replaceBuffer(key, (string)vars[key]);

                }

            }



            for (int i = 0; i < length; i++)

            {

                if (!tokenMatching(buffer1[i], buffer2[i]))

                {

                    return false;

                }

            }

            return true;

        }



        bool tokenMatching(string token1, string token2)

        {

            if (token1.Equals(token2)) return true;

            if (common.var(token1) && !common.var(token2)) return varMatching(token1, token2);

            if (!common.var(token1) && common.var(token2)) return varMatching(token2, token1);

            if (common.var(token1) && common.var(token2)) return varMatching(token1, token2);

            return false;

        }

        bool varMatching(string vartoken, string token)

        {

            if (vars.ContainsKey(vartoken))// なにこれ？

            {

                if (token.Equals((string)vars[vartoken])) // なにこれ？

                {

                    return true;

                }

                else

                {

                    return false;

                }

            }

            else

            {

                replaceBuffer(vartoken, token);

                if (vars.Contains(vartoken))

                {

                    replaceBindings(vartoken, token);

                }

                vars.Add(vartoken, token);

            }

            return true;

        }



        void replaceBuffer(string preString, string postString)

        {

            for (int i = 0; i < buffer1.Length; i++)

            {

                if (preString.Equals(buffer1[i]))

                {

                    buffer1[i] = postString;

                }

                if (preString.Equals(buffer2[i]))

                {

                    buffer2[i] = postString;

                }

            }

        }



        void replaceBindings(string preString, string postString)

        {



            foreach (string key in vars.Keys)

            {

                if (preString.Equals((string)vars[key]))

                {

                    vars.Add(key, postString);

                }

            }

        }

    }
}
