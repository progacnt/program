using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string Input_str = "";  // 入力された数字
        double Result = 0;      // 計算結果
        string Operator = null; // 押された演算子
        string SecondOp = null; // 定数計算に使用する演算子
        int pattern;
        double constant;
        bool constant_decision = false;

        private void Form1_Click(object sender, EventArgs e)
        {
            // senderの詳しい情報を取り扱えるようにする
            Button btn = (Button)sender;
            // 押されたボタンの数字(または小数点の記号)
            string text = btn.Text;
            // [入力された数字]に連結する
            Input_str += text;
            // 画面上に数字を出す
            textBox1.Text = Input_str;
        }

        private void Form1_Click_1(object sender, EventArgs e)
        {
            double num1 = Result;   // 現在の結果
            double num2;            // 入力された文字
                                    
            Button btn = (Button)sender;
            // 入力された文字が空欄なら、計算をスキップする
            if (Input_str != "")
            {
                // 入力した文字を数字に変換
                num2 = double.Parse(Input_str);
                // 四則計算
                if (Operator == "+")
                {
                    Result = num1 + num2;
                    SecondOp = Operator;
                    constant = num2;
                }
                if (Operator == "-")
                {
                    Result = num1 - num2;
                    SecondOp = Operator;
                    constant = num2;
                }
                if (Operator == "×")
                {
                    Result = num1 * num2;
                    SecondOp = Operator;
                    constant = num2;
                }
                if (Operator == "÷")
                {
                    Result = num1 / num2;
                    SecondOp = Operator;
                    constant = num2;
                }
                // 演算子を押されていなかった場合、入力されている文字をそのまま結果扱いにする
                if (Operator == null)
                    Result = num2;
            }

            //定数計算
            if (SecondOp != "" && Operator == "" && btn.Text == "=")
            {
                constant_decision = true;
                if (SecondOp == "+")
                {
                    Result = num1 + constant;
                }
                if (SecondOp == "-")
                {
                    Result = num1 - constant;
                }
                if (SecondOp == "×")
                {
                    Result = num1 * constant;
                }
                if (SecondOp == "÷")
                {
                    Result = num1 / constant;
                }
            }
            //代入計算
            if (Input_str == "" && btn.Text == "=")
            {
                if (Operator == "+")
                {
                    Result = num1 + num1;
                    SecondOp = Operator;
                    constant = num1;
                }
                if (Operator == "-")
                {
                    Result = num1 - num1;
                    SecondOp = Operator;
                    constant = num1;
                }
                if (Operator == "×")
                {
                    Result = num1 * num1;
                    SecondOp = Operator;
                    constant = num1;
                }
                if (Operator == "÷")
                {
                    Result = num1 / num1;
                    SecondOp = Operator;
                    constant = num1;
                }
            }


            // 演算子をOperator変数に入れる
            Operator = btn.Text;

            //画面に計算式を表示
            if (Operator == "=" && constant_decision == false)
            {
                if (SecondOp == "")
                {
                    textBox2.Text = textBox1.Text + " " + Operator;
                }
                else
                {
                    textBox2.Text = textBox2.Text + " " + textBox1.Text + " " + Operator;
                }
            }
            else if (Operator == "=" && constant_decision == true)
            {
                textBox2.Text = textBox1.Text + " " + SecondOp + " " + constant + " " + Operator;
            }

            

            // 画面に計算結果を表示する
            if (Result.ToString() == "∞")
                textBox1.Text = "undifined";
            else
                textBox1.Text = Result.ToString();

            if (Operator != "=" )
            {
                textBox2.Text = textBox1.Text + " " + Operator;
                constant_decision = false;
            }

            //最初に"-"を打った時の表示
            if (Operator != "="　&& textBox1.Text == "0")
            {
                textBox2.Text = textBox1.Text + " " + Operator;
                constant_decision = false;
            }
            
            // 今入力されている数字をリセットする
            Input_str = "";
            // 今入力されている演算子をリセットする
            if (Operator == "=")
            {
                Operator = "";
            }
        }
    

            private void button17_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                //全てリセットする
                if (btn.Text == "C")
                {
                    Result = 0;
                    Operator = null;
                    SecondOp = null;
                    textBox1.Text = "0";
                    textBox2.Text = "";
                    Input_str = "";
                }
                //最後にした入力をリセットする
                else if (btn.Text == "CE")
                {
                    textBox1.Text = "";
                    Input_str = "";
                    if (Operator == "")
                        Result = 0;
                }
            }

        private void button21_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(textBox1.Text);
            
            // senderの詳しい情報を取り扱えるようにする
            Button btn = (Button)sender;
            // 入力された文字が空欄なら、計算をスキップする
            if (Input_str != "")
            {
                //各演算
                if (btn.Text == "¹/x")
                {
                    pattern = 1;
                    Result = 1 / num1;
                    
                }
                if (btn.Text == "ｘ²")
                {
                    pattern = 2;
                    Result = Math.Pow(num1,2);
                    
                }
                if (btn.Text == "²√ｘ")
                {
                    pattern = 3;
                    Result = Math.Sqrt(num1);
                    
                }
                // 演算子を押されていなかった場合、入力されている文字をそのまま結果扱いにする
                if (btn.Text == null)
                    Result = num1;
            }
            //画面に出力する
            if (pattern == 1)
            {
                textBox2.Text = textBox2.Text + "1/(" + textBox1.Text + ")";
            }
            if (pattern == 2)
            {
                textBox2.Text = textBox2.Text + "sqr(" + textBox1.Text + ")";
            }
            if (pattern == 3)
            {
                textBox2.Text = textBox2.Text + "√(" + textBox1.Text + ")";
            }
            textBox1.Text = Result.ToString();

            // 今入力されている数字をリセットする
            Input_str = "";

        }

        private void button20_Click(object sender, EventArgs e)
        {
            if(Input_str != "")
            Input_str = Input_str.Remove(Input_str.Length - 1, 1);
            textBox1.Text = Input_str;
        }

        private void button24_Click(object sender, EventArgs e)
        {
                double num3 = double.Parse(textBox1.Text);
                Result = num3 - (num3 * 2);
                textBox1.Text = Result.ToString();
        }
    }
}

