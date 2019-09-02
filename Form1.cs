using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

using System.IO;//
using System.Threading;//
using System.Text.RegularExpressions;


namespace HeatMap01
{


    public partial class Form1 : Form
    {

        public class MyCollectionModel
        {
            public ObjectId Id { get; set; }

            [BsonElement("TimeStamp")]
            public string Time { get; set; }

            [BsonElement("X")]
            public string Iget_X { get; set; }

            [BsonElement("Y")]
            public string Iget_Y { get; set; }
            [BsonElement("size")]
            public string Iget_size { get; set; }
        }

        int upperX, upperX2, upperY, areaWidth, areaHeight, areaWidth2, areaHeight2;
        static int MAX = 255;



        double col_size = 2;

        //マッピングの色の変数
        double map0_0 = -10, map0_1 = -10, map0_2 = -10, map0_3 = -10, map0_4 = -10, map0_5 = -10, map0_6 = -10, map0_7 = -10, map0_8 = -10,
               map0_9 = -10, map0_10 = -10, map0_11 = -10, map0_12 = -10, map0_13 = -10, map0_14 = -10, map0_15 = -10, map0_16 = -10, map0_17 = -10,
               map0_18 = -10, map0_19 = -10, map0_20 = -10, map0_21 = -10, map0_22 = -10, map0_23 = -10, map0_24 = -10, map0_25 = -10,
               map0_26 = -10, map0_27 = -10, map0_28 = -10, map0_29 = -10, map0_30 = -10, map0_31 = -10, map0_32 = -10, map0_33 = -10, map0_34 = -10;//1の段

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        double map1_0 = -10, map1_1 = -10, map1_2 = -10, map1_3 = -10, map1_4 = -10, map1_5 = -10, map1_6 = -10, map1_7 = -10, map1_8 = -10,
               map1_9 = -10, map1_10 = -10, map1_11 = -10, map1_12 = -10, map1_13 = -10, map1_14 = -10, map1_15 = -10, map1_16 = -10, map1_17 = -10,
               map1_18 = -10, map1_19 = -10, map1_20 = -10, map1_21 = -10, map1_22 = -10, map1_23 = -10, map1_24 = -10, map1_25 = -10,
               map1_26 = -10, map1_27 = -10, map1_28 = -10, map1_29 = -10, map1_30 = -10, map1_31 = -10, map1_32 = -10, map1_33 = -10, map1_34 = -10;//2の段

        double map2_0 = -10, map2_1 = -10, map2_2 = -10, map2_3 = -10, map2_4 = -10, map2_5 = -10, map2_6 = -10, map2_7 = -10, map2_8 = -10,
            map2_9 = -10, map2_10 = -10, map2_11 = -10, map2_12 = -10, map2_13 = -10, map2_14 = -10, map2_15 = -10, map2_16 = -10, map2_17 = -10,
              map2_18 = -10, map2_19 = -10, map2_20 = -10, map2_21 = -10, map2_22 = -10, map2_23 = -10, map2_24 = -10, map2_25 = -10,
              map2_26 = -10, map2_27 = -10, map2_28 = -10, map2_29 = -10, map2_30 = -10, map2_31 = -10, map2_32 = -10, map2_33 = -10, map2_34 = -10;//3の段

        double map3_0 = -10, map3_1 = -10, map3_2 = -10, map3_3 = -10, map3_4 = -10, map3_5 = -10, map3_6 = -10, map3_7 = -10, map3_8 = -10,
            map3_9 = -10, map3_10 = -10, map3_11 = -10, map3_12 = -10, map3_13 = -10, map3_14 = -10, map3_15 = -10, map3_16 = -10, map3_17 = -10,
              map3_18 = -10, map3_19 = -10, map3_20 = -10, map3_21 = -10, map3_22 = -10, map3_23 = -10, map3_24 = -10, map3_25 = -10,
              map3_26 = -10, map3_27 = -10, map3_28 = -10, map3_29 = -10, map3_30 = -10, map3_31 = -10, map3_32 = -10, map3_33 = -10, map3_34 = -10;//4の段

        double map4_0 = -10, map4_1 = -10, map4_2 = -10, map4_3 = -10, map4_4 = -10, map4_5 = -10, map4_6 = -10, map4_7 = -10, map4_8 = -10,
            map4_9 = -10, map4_10 = -10, map4_11 = -10, map4_12 = -10, map4_13 = -10, map4_14 = -10, map4_15 = -10, map4_16 = -10, map4_17 = -10,
              map4_18 = -10, map4_19 = -10, map4_20 = -10, map4_21 = -10, map4_22 = -10, map4_23 = -10, map4_24 = -10, map4_25 = -10,
              map4_26 = -10, map4_27 = -10, map4_28 = -10, map4_29 = -10, map4_30 = -10, map4_31 = -10, map4_32 = -10, map4_33 = -10, map4_34 = -10;//5の段

        double map5_0 = -10, map5_1 = -10, map5_2 = -10, map5_3 = -10, map5_4 = -10, map5_5 = -10, map5_6 = -10, map5_7 = -10, map5_8 = -10,
            map5_9 = -10, map5_10 = -10, map5_11 = -10, map5_12 = -10, map5_13 = -10, map5_14 = -10, map5_15 = -10, map5_16 = -10, map5_17 = -10,
              map5_18 = -10, map5_19 = -10, map5_20 = -10, map5_21 = -10, map5_22 = -10, map5_23 = -10, map5_24 = -10, map5_25 = -10,
              map5_26 = -10, map5_27 = -10, map5_28 = -10, map5_29 = -10, map5_30 = -10, map5_31 = -10, map5_32 = -10, map5_33 = -10, map5_34 = -10;//6の段

        double map6_0 = -10, map6_1 = -10, map6_2 = -10, map6_3 = -10, map6_4 = -10, map6_5 = -10, map6_6 = -10, map6_7 = -10, map6_8 = -10,
            map6_9 = -10, map6_10 = -10, map6_11 = -10, map6_12 = -10, map6_13 = -10, map6_14 = -10, map6_15 = -10, map6_16 = -10, map6_17 = -10,
              map6_18 = -10, map6_19 = -10, map6_20 = -10, map6_21 = -10, map6_22 = -10, map6_23 = -10, map6_24 = -10, map6_25 = -10,
              map6_26 = -10, map6_27 = -10, map6_28 = -10, map6_29 = -10, map6_30 = -10, map6_31 = -10, map6_32 = -10, map6_33 = -10, map6_34 = -10;//7の段

        double map7_0 = -10, map7_1 = -10, map7_2 = -10, map7_3 = -10, map7_4 = -10, map7_5 = -10, map7_6 = -10, map7_7 = -10, map7_8 = -10,
            map7_9 = -10, map7_10 = -10, map7_11 = -10, map7_12 = -10, map7_13 = -10, map7_14 = -10, map7_15 = -10, map7_16 = -10, map7_17 = -10,
              map7_18 = -10, map7_19 = -10, map7_20 = -10, map7_21 = -10, map7_22 = -10, map7_23 = -10, map7_24 = -10, map7_25 = -10,
              map7_26 = -10, map7_27 = -10, map7_28 = -10, map7_29 = -10, map7_30 = -10, map7_31 = -10, map7_32 = -10, map7_33 = -10, map7_34 = -10;//8の段

        double map8_0 = -10, map8_1 = -10, map8_2 = -10, map8_3 = -10, map8_4 = -10, map8_5 = -10, map8_6 = -10, map8_7 = -10, map8_8 = -10,
            map8_9 = -10, map8_10 = -10, map8_11 = -10, map8_12 = -10, map8_13 = -10, map8_14 = -10, map8_15 = -10, map8_16 = -10, map8_17 = -10,
              map8_18 = -10, map8_19 = -10, map8_20 = -10, map8_21 = -10, map8_22 = -10, map8_23 = -10, map8_24 = -10, map8_25 = -10,
              map8_26 = -10, map8_27 = -10, map8_28 = -10, map8_29 = -10, map8_30 = -10, map8_31 = -10, map8_32 = -10, map8_33 = -10, map8_34 = -10;//9の段

        double map9_0 = -10, map9_1 = -10, map9_2 = -10, map9_3 = -10, map9_4 = -10, map9_5 = -10, map9_6 = -10, map9_7 = -10, map9_8 = -10,
            map9_9 = -10, map9_10 = -10, map9_11 = -10, map9_12 = -10, map9_13 = -10, map9_14 = -10, map9_15 = -10, map9_16 = -10, map9_17 = -10,
              map9_18 = -10, map9_19 = -10, map9_20 = -10, map9_21 = -10, map9_22 = -10, map9_23 = -10, map9_24 = -10, map9_25 = -10,
              map9_26 = -10, map9_27 = -10, map9_28 = -10, map9_29 = -10, map9_30 = -10, map9_31 = -10, map9_32 = -10, map9_33 = -10, map9_34 = -10;//10の段

        double map10_0 = -10, map10_1 = -10, map10_2 = -10, map10_3 = -10, map10_4 = -10, map10_5 = -10, map10_6 = -10, map10_7 = -10, map10_8 = -10,
            map10_9 = -10, map10_10 = -10, map10_11 = -10, map10_12 = -10, map10_13 = -10, map10_14 = -10, map10_15 = -10, map10_16 = -10, map10_17 = -10,
               map10_18 = -10, map10_19 = -10, map10_20 = -10, map10_21 = -10, map10_22 = -10, map10_23 = -10, map10_24 = -10, map10_25 = -10,
               map10_26 = -10, map10_27 = -10, map10_28 = -10, map10_29 = -10, map10_30 = -10, map10_31 = -10, map10_32 = -10, map10_33 = -10, map10_34 = -10;//11の段

        double map11_0 = -10, map11_1 = -10, map11_2 = -10, map11_3 = -10, map11_4 = -10, map11_5 = -10, map11_6 = -10, map11_7 = -10, map11_8 = -10,
            map11_9 = -10, map11_10 = -10, map11_11 = -10, map11_12 = -10, map11_13 = -10, map11_14 = -10, map11_15 = -10, map11_16 = -10, map11_17 = -10,
              map11_18 = -10, map11_19 = -10, map11_20 = -10, map11_21 = -10, map11_22 = -10, map11_23 = -10, map11_24 = -10, map11_25 = -10,
              map11_26 = -10, map11_27 = -10, map11_28 = -10, map11_29 = -10, map11_30 = -10, map11_31 = -10, map11_32 = -10, map11_33 = -10, map11_34 = -10;//12の段

        double map12_0 = -10, map12_1 = -10, map12_2 = -10, map12_3 = -10, map12_4 = -10, map12_5 = -10, map12_6 = -10, map12_7 = -10, map12_8 = -10,
            map12_9 = -10, map12_10 = -10, map12_11 = -10, map12_12 = -10, map12_13 = -10, map12_14 = -10, map12_15 = -10, map12_16 = -10, map12_17 = -10,
             map12_18 = -10, map12_19 = -10, map12_20 = -10, map12_21 = -10, map12_22 = -10, map12_23 = -10, map12_24 = -10, map12_25 = -10,
             map12_26 = -10, map12_27 = -10, map12_28 = -10, map12_29 = -10, map12_30 = -10, map12_31 = -10, map12_32 = -10, map12_33 = -10, map12_34 = -10;//13の段

        double map13_0 = -10, map13_1 = -10, map13_2 = -10, map13_3 = -10, map13_4 = -10, map13_5 = -10, map13_6 = -10, map13_7 = -10, map13_8 = -10,
            map13_9 = -10, map13_10 = -10, map13_11 = -10, map13_12 = -10, map13_13 = -10, map13_14 = -10, map13_15 = -10, map13_16 = -10, map13_17 = -10,
             map13_18 = -10, map13_19 = -10, map13_20 = -10, map13_21 = -10, map13_22 = -10, map13_23 = -10, map13_24 = -10, map13_25 = -10,
             map13_26 = -10, map13_27 = -10, map13_28 = -10, map13_29 = -10, map13_30 = -10, map13_31 = -10, map13_32 = -10, map13_33 = -10, map13_34 = -10;//14の段

        double map14_0 = -10, map14_1 = -10, map14_2 = -10, map14_3 = -10, map14_4 = -10, map14_5 = -10, map14_6 = -10, map14_7 = -10, map14_8 = -10,
            map14_9 = -10, map14_10 = -10, map14_11 = -10, map14_12 = -10, map14_13 = -10, map14_14 = -10, map14_15 = -10, map14_16 = -10, map14_17 = -10,
             map14_18 = -10, map14_19 = -10, map14_20 = -10, map14_21 = -10, map14_22 = -10, map14_23 = -10, map14_24 = -10, map14_25 = -10,
             map14_26 = -10, map14_27 = -10, map14_28 = -10, map14_29 = -10, map14_30 = -10, map14_31 = -10, map14_32 = -10, map14_33 = -10, map14_34 = -10;//15の段

        double map_waitlane0_0 = -10, map_waitlane0_1 = -10, map_waitlane0_2 = -10, map_waitlane0_3 = -10, map_waitlane0_4 = -10, map_waitlane0_5 = -10, map_waitlane0_6 = -10,
            map_waitlane0_7 = -10, map_waitlane0_8 = -10, map_waitlane0_9 = -10, map_waitlane0_10 = -10, map_waitlane0_11 = -10, map_waitlane0_12 = -10, map_waitlane0_13 = -10,
            map_waitlane0_14 = -10, map_waitlane0_15 = -10, map_waitlane0_16 = -10, map_waitlane0_17 = -10, map_waitlane0_18 = -10, map_waitlane0_19 = -10, map_waitlane0_20 = -10, map_waitlane0_21 = -10,
            map_waitlane0_22 = -10, map_waitlane0_23 = -10, map_waitlane0_24 = -10, map_waitlane0_25 = -10, map_waitlane0_26 = -10, map_waitlane0_27 = -10;

        double map_waitlane1_0 = -10, map_waitlane1_1 = -10, map_waitlane1_2 = -10, map_waitlane1_3 = -10, map_waitlane1_4 = -10, map_waitlane1_5 = -10, map_waitlane1_6 = -10,
          map_waitlane1_7 = -10, map_waitlane1_8 = -10, map_waitlane1_9 = -10, map_waitlane1_10 = -10, map_waitlane1_11 = -10, map_waitlane1_12 = -10, map_waitlane1_13 = -10,
          map_waitlane1_14 = -10, map_waitlane1_15 = -10, map_waitlane1_16 = -10, map_waitlane1_17 = -10, map_waitlane1_18 = -10, map_waitlane1_19 = -10, map_waitlane1_20 = -10, map_waitlane1_21 = -10,
          map_waitlane1_22 = -10, map_waitlane1_23 = -10, map_waitlane1_24 = -10, map_waitlane1_25 = -10, map_waitlane1_26 = -10, map_waitlane1_27 = -10;

        double map_waitlane2_0 = -10, map_waitlane2_1 = -10, map_waitlane2_2 = -10, map_waitlane2_3 = -10, map_waitlane2_4 = -10, map_waitlane2_5 = -10, map_waitlane2_6 = -10,
          map_waitlane2_7 = -10, map_waitlane2_8 = -10, map_waitlane2_9 = -10, map_waitlane2_10 = -10, map_waitlane2_11 = -10, map_waitlane2_12 = -10, map_waitlane2_13 = -10,
          map_waitlane2_14 = -10, map_waitlane2_15 = -10, map_waitlane2_16 = -10, map_waitlane2_17 = -10, map_waitlane2_18 = -10, map_waitlane2_19 = -10, map_waitlane2_20 = -10, map_waitlane2_21 = -10,
          map_waitlane2_22 = -10, map_waitlane2_23 = -10, map_waitlane2_24 = -10, map_waitlane2_25 = -10, map_waitlane2_26 = -10, map_waitlane2_27 = -10;

        double map_waitlane3_0 = -10, map_waitlane3_1 = -10, map_waitlane3_2 = -10, map_waitlane3_3 = -10, map_waitlane3_4 = -10, map_waitlane3_5 = -10, map_waitlane3_6 = -10,
          map_waitlane3_7 = -10, map_waitlane3_8 = -10, map_waitlane3_9 = -10, map_waitlane3_10 = -10, map_waitlane3_11 = -10, map_waitlane3_12 = -10, map_waitlane3_13 = -10,
          map_waitlane3_14 = -10, map_waitlane3_15 = -10, map_waitlane3_16 = -10, map_waitlane3_17 = -10, map_waitlane3_18 = -10, map_waitlane3_19 = -10, map_waitlane3_20 = -10, map_waitlane3_21 = -10,
          map_waitlane3_22 = -10, map_waitlane3_23 = -10, map_waitlane3_24 = -10, map_waitlane3_25 = -10, map_waitlane3_26 = -10, map_waitlane3_27 = -10;



        public Form1()
        {
            InitializeComponent();
            upperX = 300; // int.Parse(textBox1.Text);
            upperX2 = 550;
            upperY = 10; //int.Parse(textBox2.Text);
            areaWidth = 168;// int.Parse(textBox3.Text);
            areaHeight = 392; //int.Parse(textBox4.Text);
            areaWidth2 = 112;
            areaHeight2 =392 ;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {//データ７つ緑
            int step = 28; //15:35  3:7 6:14
            int cntr = areaWidth / step/2;
            int max = 10;
            int min = -10;
            Graphics g = this.CreateGraphics();

            double val = -10;
            for (int i = 0; i < areaWidth / step; i++) {//210
                for (int j = 0; j < areaHeight / step; j++)//490
                {

                   //1列目
                    if (i == 0 && j == 0) val = map0_0;
                    if (i == 0 && j == 1) val = map0_1;
                    if (i == 0 && j == 2) val = map0_2;
                    if (i == 0 && j == 3) val = map0_3;
                    if (i == 0 && j == 4) val = map0_4;
                    if (i == 0 && j == 5) val = map0_5;
                    if (i == 0 && j == 6) val = map0_6;
                    if (i == 0 && j == 7) val = map0_7;
                    if (i == 0 && j == 8) val = map0_8;
                    if (i == 0 && j == 9) val = map0_9;
                    if (i == 0 && j == 10) val = map0_10;
                    if (i == 0 && j == 11) val = map0_11;
                    if (i == 0 && j == 12) val = map0_12;
                    if (i == 0 && j == 13) val = map0_13;
                    

                    //2列目
                    if (i == 1 && j == 0) val = map1_0;
                    if (i == 1 && j == 1) val = map1_1;
                    if (i == 1 && j == 2) val = map1_2;
                    if (i == 1 && j == 3) val = map1_3;
                    if (i == 1 && j == 4) val = map1_4;
                    if (i == 1 && j == 5) val = map1_5;
                    if (i == 1 && j == 6) val = map1_6;
                    if (i == 1 && j == 7) val = map1_7;
                    if (i == 1 && j == 8) val = map1_8;
                    if (i == 1 && j == 9) val = map1_9;
                    if (i == 1 && j == 10) val = map1_10;
                    if (i == 1 && j == 11) val = map1_11;
                    if (i == 1 && j == 12) val = map1_12;
                    if (i == 1 && j == 13) val = map1_13;
                  

                    //3列目
                    if (i == 2 && j == 0) val = map2_0;
                    if (i == 2 && j == 1) val = map2_1;
                    if (i == 2 && j == 2) val = map2_2;
                    if (i == 2 && j == 3) val = map2_3;
                    if (i == 2 && j == 4) val = map2_4;
                    if (i == 2 && j == 5) val = map2_5;
                    if (i == 2 && j == 6) val = map2_6;
                    if (i == 2 && j == 7) val = map2_7;
                    if (i == 2 && j == 8) val = map2_8;
                    if (i == 2 && j == 9) val = map2_9;
                    if (i == 2 && j == 10) val = map2_10;
                    if (i == 2 && j == 11) val = map2_11;
                    if (i == 2 && j == 12) val = map2_12;
                    if (i == 2 && j == 13) val = map2_13;
                    

                    //4列目
                    if (i == 3 && j == 0) val = map3_0;
                    if (i == 3 && j == 1) val = map3_1;
                    if (i == 3 && j == 2) val = map3_2;
                    if (i == 3 && j == 3) val = map3_3;
                    if (i == 3 && j == 4) val = map3_4;
                    if (i == 3 && j == 5) val = map3_5;
                    if (i == 3 && j == 6) val = map3_6;
                    if (i == 3 && j == 7) val = map3_7;
                    if (i == 3 && j == 8) val = map3_8;
                    if (i == 3 && j == 9) val = map3_9;
                    if (i == 3 && j == 10) val = map3_10;
                    if (i == 3 && j == 11) val = map3_11;
                    if (i == 3 && j == 12) val = map3_12;
                    if (i == 3 && j == 13) val = map3_13;
                    

                    //5列目
                    if (i == 4 && j == 0) val = map4_0;
                    if (i == 4 && j == 1) val = map4_1;
                    if (i == 4 && j == 2) val = map4_2;
                    if (i == 4 && j == 3) val = map4_3;
                    if (i == 4 && j == 4) val = map4_4;
                    if (i == 4 && j == 5) val = map4_5;
                    if (i == 4 && j == 6) val = map4_6;
                    if (i == 4 && j == 7) val = map4_7;
                    if (i == 4 && j == 8) val = map4_8;
                    if (i == 4 && j == 9) val = map4_9;
                    if (i == 4 && j == 10) val = map4_10;
                    if (i == 4 && j == 11) val = map4_11;
                    if (i == 4 && j == 12) val = map4_12;
                    if (i == 4 && j == 13) val = map4_13;
                   
                    
                    //6列目
                    if (i == 5 && j == 0) val = map5_0;
                    if (i == 5 && j == 1) val = map5_1;
                    if (i == 5 && j == 2) val = map5_2;
                    if (i == 5 && j == 3) val = map5_3;
                    if (i == 5 && j == 4) val = map5_4;
                    if (i == 5 && j == 5) val = map5_5;
                    if (i == 5 && j == 6) val = map5_6;
                    if (i == 5 && j == 7) val = map5_7;
                    if (i == 5 && j == 8) val = map5_8;
                    if (i == 5 && j == 9) val = map5_9;
                    if (i == 5 && j == 10) val = map5_10;
                    if (i == 5 && j == 11) val = map5_11;
                    if (i == 5 && j == 12) val = map5_12;
                    if (i == 5 && j == 13) val = map5_13;
                   

            

                    SolidBrush brsh = new SolidBrush(ColorScaleBCGYR((val-min)/(max-min))); // 数値から色を計算導出 //Console.WriteLine(val);]
                    g.FillRectangle(brsh, upperX+i*step, upperY+j*step, step, step); // 正方形でマッピングしている

                }
            }
            for (int i = 0; i < areaWidth2 / step; i++)
            {//210
                for (int j = 0; j < areaHeight2 / step; j++)//490
                {

                    //1列目
                    if (i == 0 && j == 0) val = map_waitlane0_0;
                    if (i == 0 && j == 1) val = map_waitlane0_1;
                    if (i == 0 && j == 2) val = map_waitlane0_2;
                    if (i == 0 && j == 3) val = map_waitlane0_3 ;
                    if (i == 0 && j == 4) val = map_waitlane0_4; 
                    if (i == 0 && j == 5) val = map_waitlane0_5;
                    if (i == 0 && j == 6) val = map_waitlane0_6;
                    if (i == 0 && j == 7) val = map_waitlane0_7;
                    if (i == 0 && j == 8) val = map_waitlane0_8;
                    if (i == 0 && j == 9) val = map_waitlane0_9;
                    if (i == 0 && j == 10) val = map_waitlane0_10;
                    if (i == 0 && j == 11) val = map_waitlane0_11;
                    if (i == 0 && j == 12) val = map_waitlane0_12;
                    if (i == 0 && j == 13) val = map_waitlane0_13;
                   
                    

                    //2列目
                    if (i == 1 && j == 0) val = map_waitlane1_0;
                    if (i == 1 && j == 1) val = map_waitlane1_1;
                    if (i == 1 && j == 2) val = map_waitlane1_2;
                    if (i == 1 && j == 3) val = map_waitlane1_3;
                    if (i == 1 && j == 4) val = map_waitlane1_4;
                    if (i == 1 && j == 5) val = map_waitlane1_5;
                    if (i == 1 && j == 6) val = map_waitlane1_6;
                    if (i == 1 && j == 7) val = map_waitlane1_7;
                    if (i == 1 && j == 8) val = map_waitlane1_8;
                    if (i == 1 && j == 9) val = map_waitlane1_9;
                    if (i == 1 && j == 10) val = map_waitlane1_10;
                    if (i == 1 && j == 11) val = map_waitlane1_11;
                    if (i == 1 && j == 12) val = map_waitlane1_12;
                    if (i == 1 && j == 13) val = map_waitlane1_13;
                
                   
                    //3列目
                    if (i == 2 && j == 0) val = map_waitlane2_0;
                    if (i == 2 && j == 1) val = map_waitlane2_1;
                    if (i == 2 && j == 2) val = map_waitlane2_2;
                    if (i == 2 && j == 3) val = map_waitlane2_3;
                    if (i == 2 && j == 4) val = map_waitlane2_4;
                    if (i == 2 && j == 5) val = map_waitlane2_5;
                    if (i == 2 && j == 6) val = map_waitlane2_6;
                    if (i == 2 && j == 7) val = map_waitlane2_7;
                    if (i == 2 && j == 8) val = map_waitlane2_8;
                    if (i == 2 && j == 9) val = map_waitlane2_9;
                    if (i == 2 && j == 10) val = map_waitlane2_10;
                    if (i == 2 && j == 11) val = map_waitlane2_11;
                    if (i == 2 && j == 12) val = map_waitlane2_12;
                    if (i == 2 && j == 13) val = map_waitlane2_13;
                   
                   

                    //4列目
                    if (i == 3 && j == 0) val = map_waitlane3_0;
                    if (i == 3 && j == 1) val = map_waitlane3_1;
                    if (i == 3 && j == 2) val = map_waitlane3_2;
                    if (i == 3 && j == 3) val = map_waitlane3_3;
                    if (i == 3 && j == 4) val = map_waitlane3_4;
                    if (i == 3 && j == 5) val = map_waitlane3_5;
                    if (i == 3 && j == 6) val = map_waitlane3_6;
                    if (i == 3 && j == 7) val = map_waitlane3_7;
                    if (i == 3 && j == 8) val = map_waitlane3_8;
                    if (i == 3 && j == 9) val = map_waitlane3_9;
                    if (i == 3 && j == 10) val = map_waitlane3_10;
                    if (i == 3 && j == 11) val = map_waitlane3_11;
                    if (i == 3 && j == 12) val = map_waitlane3_12;
                    if (i == 3 && j == 13) val = map_waitlane3_13;
                 
                    

                    

                    SolidBrush brsh = new SolidBrush(ColorScaleBCGYR((val - min) / (max - min))); // 数値から色を計算導出 //Console.WriteLine(val);]
                    g.FillRectangle(brsh, upperX2 + i * step, upperY + j * step, step, step); // 正方形でマッピングしている

                }
            }
        }

        // ヒートマップのカラーを作成するメソッド
        private Color ColorScaleBCGYR(double in_value)
        {
            // 0.0～1.0 の範囲の値をサーモグラフィみたいな色にする
            // 0.0                    1.0
            // 青    水    緑    黄    赤
            // 最小値以下 = 青
            // 最大値以上 = 赤
            Color ret;
            System.Random rm = new System.Random(1000);
            int r, g, b;    // RGB値
            double value = in_value;//in_value;
            
            double tmp_val = Math.Cos(4 * Math.PI * value);
            int col_val = 0;//(int)((-tmp_val / 2 + 0.5) * 255);


           

            if (value >= (4.0 / 4.0)) { r = 255; g = 0; b = 0; }   // 赤
            else if (value >= (3.0 / 4.0)) { r = 255; g = col_val; b = 0; }   // 黄～赤
            else if (value >= (2.0 / 4.0)) { r = col_val; g = 255; b = 0; }   // 緑～黄
            else if (value >= (1.0 / 4.0)) { r = 0; g = 255; b = col_val; }   // 水～緑
            else if (value >= (0.0 / 4.0)) { r = 0; g = col_val; b = 255; }   // 青～水
            else { r = 0; g = 0; b = 255; }   // 青

            ret = Color.FromArgb(r, g, b);

            return ret;
        }

        // 枠の表示
        private void Form1_Paint(object sender, PaintEventArgs e)//, PaintEventArgs f)
        {
            Pen pen = new Pen(Color.Black);
            e.Graphics.DrawRectangle(pen, upperX, upperY, areaWidth, areaHeight);
     
            e.Graphics.DrawRectangle(pen, upperX2, upperY, areaWidth2, areaHeight2);
        }

        private void label6_Click(object sender, EventArgs e)
        {


            ///なにかあった
        }

        private void button3_Click(object sender, EventArgs e)//FUsion X
        {
            string connectionString = "mongodb://s1621007:kait_807@153.120.129.159";
            MongoClient client = new MongoClient(connectionString);

            IMongoDatabase db = client.GetDatabase("s1621007");
           IMongoCollection<MyCollectionModel> collection = db.GetCollection<MyCollectionModel>("store");

            // Table ID取得
            /*  string tableId =null;

              FusiontablesService fusiontablesService
                  = new FusiontablesService(new BaseClientService.Initializer()
                  {
                      HttpClientInitializer = GetCredential().Result,
                      ApplicationName = ""
                  });
              // テーブルの設定

              Table tableData = fusiontablesService.Table.Get(tableId).Execute();
              */

            //select
            string respX = "";
            string respY = ""; //aho
            string respSize = "";
            try
            {
                var sql = collection.AsQueryable().Where(x => x.Time.Contains(textBox1.Text)).ToList() ;//"SELECT  FROM " + tableId + " WHERE TimeStamp LIKE " + textBox1.Text;

                for (int i = 0; i < sql.Count; i++)
                {
                    textBox2.Text += sql[i].Id + " , " + sql[i].Iget_X + " , " + sql[i].Iget_Y + ", " + sql[i].Iget_size + "\r\n";

                }

                var sqly = "100"; //"SELECT Y FROM " + tableId +" WHERE TimeStamp LIKE " + textBox1.Text;
                var sqlsize = "80";//"SELECT size FROM " + tableId +" WHERE TimeStamp LIKE " + textBox1.Text;

                var resultsize = 100;//fusiontablesService.Query.SqlGet(sqlsize).Execute();//aho
                var resulty = 100; //fusiontablesService.Query.SqlGet(sqly).Execute();//aho
                var result = 80; //fusiontablesService.Query.SqlGet(sql).Execute();

                int aaa = 0;

                var Numrow = sql.Count;
                Console.WriteLine("{0},{1}", sql,Numrow);


                int numRow = sql.Count; //result.Rows.Count;
                if (numRow > 0)
                {
                    for (int i = 0; i < numRow; i++)
                    {//取得件数指定()
                        var numX = int.Parse(sql[i].Iget_X);
                        var numY = int.Parse(sql[i].Iget_Y);
                        var numSize = int.Parse(sql[i].Iget_size);
                        var json = sql[i].Iget_X;
                        var jsony = sql[i].Iget_Y;

                        var jsonsize = sql[i].Iget_size;

                        // string json = "800";// JsonConvert.SerializeObject(result.Rows[i]);

                        // string jsony = "300";//JsonConvert.SerializeObject(resulty.Rows[i]);
                        // string jsonsize = "1";//JsonConvert.SerializeObject(resultsize.Rows[i]);


                        //  json = Regex.Replace(json, @"[^0-9]", "\r\n");//数字だけにするよ
                        // int numX = 800; //int.Parse(json);//string から int

                        //  jsony = Regex.Replace(jsony, @"[^0-9]", "\r\n");//数字だけにするよaho
                        // int numY = 300; //int.Parse(jsony);//string から int aho

                        //  jsonsize = Regex.Replace(jsonsize, @"[^0-9]", "\r\n");//数字だけにするよaho
                        // int numSize = 50; //int.Parse(jsonsize);//string から int aho

                        //henkansitemapping//

                        Console.WriteLine("{0},{1},{2}",numX, numY, numSize);

                        map0_0 = map0_0 + col_size;

                        if (800 < numX && numX < 900&&100<numY&&numY<200) { map_waitlane0_0 = map_waitlane0_0 + col_size; }//例x800~900,Y100~200の時








                        //1dan//


                        if (729 < numX && numX < 729 + ( 903 - 729)/6 *1  && Math.Pow(8.131/174.24 , 1/-0.802) > numSize && numSize >  Math.Pow(8.331/174.24 , 1/-0.802)) map0_0 = map0_0 + col_size;
                        if (729 - 239 / 13 * 1 < numX && numX < (729 - 239 / 13 * 1) + ((903 + 107 / 13 * 1) - (729 - 239 / 13 * 1)) / 6 * 1 && Math.Pow(7.694 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(7.894 / 174.24, 1 / -0.802)) map0_1 = map0_1 + col_size;
                        if (729 - 239 / 13 * 2< numX && numX < (729 - 239 / 13 * 2) + ( ( 903 + 107 / 13 * 2 ) - ( 729 - 239 / 13 * 2 ) ) / 6 * 1 && Math.Pow(7.257 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(7.457 / 174.24, 1 / -0.802)) map0_2 = map0_2 + col_size;
                        if (729 - 239 / 13 * 3 < numX && numX < (729 - 239 / 13 * 3) + ((903 + 107 / 13 * 3) - (729 - 239 / 13 * 3)) / 6 * 1 && Math.Pow(6.82 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(7.02 / 174.24, 1 / -0.802)) map0_3 = map0_3 + col_size;
                        if (729 - 239 / 13 * 4 < numX && numX < (729 - 239 / 13 * 4) + ((903 + 107 / 13 * 4) - (729 - 239 / 13 * 4)) / 6 * 1 && Math.Pow(6.383/ 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(6.583 / 174.24, 1 / -0.802)) map0_4 = map0_4 + col_size;
                        if (729 - 239 / 13 * 5 < numX && numX < (729 - 239 / 13 * 5) + ((903 + 107 / 13 * 5) - (729 - 239 / 13 * 5)) / 6 * 1 && Math.Pow(5.946 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(6.146 / 174.24, 1 / -0.802)) map0_5 = map0_5 + col_size;
                        if (729 - 239 / 13 * 6 < numX && numX < (729 - 239 / 13 * 6) + ((903 + 107 / 13 * 6) - (729 - 239 / 13 * 6)) / 6 * 1 && Math.Pow(5.509 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(5.709 / 174.24, 1 / -0.802)) map0_6 = map0_6 + col_size;
                        if (729 - 239 / 13 * 7 < numX && numX < (729 - 239 / 13 * 7) + ((903 + 107 / 13 * 7) - (729 - 239 / 13 * 7)) / 6 * 1 && Math.Pow(5.072 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(5.272 / 174.24, 1 / -0.802)) map0_7 = map0_7 + col_size;
                        if (729 - 239 / 13 * 8 < numX && numX < (729 - 239 / 13 * 8) + ((903 + 107 / 13 * 8) - (729 - 239 / 13 * 8)) / 6 * 1 && Math.Pow(4.635/ 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(4.835 / 174.24, 1 / -0.802)) map0_8 = map0_8 + col_size;
                        if (729 - 239 / 13 * 9 < numX && numX < (729 - 239 / 13 * 9) + ((903 + 107 / 13 * 9) - (729 - 239 / 13 * 9)) / 6 * 1 && Math.Pow(4.198 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(4.398 / 174.24, 1 / -0.802)) map0_9 = map0_9 + col_size;
                        if (729 - 239 / 13 * 10 < numX && numX < (729 - 239 / 13 * 10) + ((903 + 107 / 13 * 10) - (729 - 239 / 13 * 10)) / 6 * 1 && Math.Pow(3.761 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(3.961 / 174.24, 1 / -0.802)) map0_10 = map0_10 + col_size;
                        if (729 - 239 / 13 * 11 < numX && numX < (729 - 239 / 13 * 11) + ((903 + 107 / 13 * 11) - (729 - 239 / 13 * 11)) / 6 * 1 && Math.Pow(3.324 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(3.524 / 174.24, 1 / -0.802)) map0_11 = map0_11 + col_size;
                        if (729 - 239 / 13 * 12 < numX && numX < (729 - 239 / 13 * 12) + ((903 + 107 / 13 * 12) - (729 - 239 / 13 * 12)) / 6 * 1 && Math.Pow(2.887 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(3.087 / 174.24, 1 / -0.802)) map0_12 = map0_12 + col_size;
                        if (729 - 239 / 13 * 13 < numX && numX < (729 - 239 / 13 * 13) + ((903 + 107 / 13 * 13) - (729 - 239 / 13 * 13)) / 6 * 1 && Math.Pow(2.45 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(2.65 / 174.24, 1 / -0.802)) map0_13 = map0_13 + col_size;
                       


                        //2dan//

                        if (729 + (903 - 729) / 6 * 1 < numX && numX < 729 + (903 - 729) / 6 * 2 && Math.Pow(8.131 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(8.331 / 174.24, 1 / -0.802)) map1_0 = map1_0 + col_size;
                        if ((729 - 239 / 13 * 1) + ((903 + 107 / 13 * 1) - (729 - 239 / 13 * 1)) / 6 * 1 < numX && numX < (729 - 239 / 13 * 1) + ((903 + 107 / 31 * 1) - (729 - 239 / 13 * 1)) / 6 * 2 && Math.Pow(7.694 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(7.894 / 174.24, 1 / -0.802)) map1_1 = map1_1 + col_size;
                        if ((729 - 239 / 13 * 2) + ((903 + 107 / 13 * 2) - (729 - 239 / 13 * 2)) / 6 * 1 < numX && numX < (729 - 239 / 13 * 2) + ((903 + 107 / 13 * 2) - (729 - 239 / 13 * 2)) / 6 * 2 && Math.Pow(7.257 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(7.457 / 174.24, 1 / -0.802)) map1_2 = map1_2 + col_size;
                        if ((729 - 239 / 13 * 3) + ((903 + 107 / 13 * 3) - (729 - 239 / 13 * 3)) / 6 * 1 < numX && numX < (729 - 239 / 13 * 3) + ((903 + 107 / 13 * 3) - (729 - 239 / 13 * 3)) / 6 * 2 && Math.Pow(6.82 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(7.02 / 174.24, 1 / -0.802)) map1_3 = map1_3 + col_size;
                        if ((729 - 239 / 13 * 4) + ((903 + 107 / 13 * 4) - (729 - 239 / 13 * 4)) / 6 * 1 < numX && numX < (729 - 239 / 13 * 4) + ((903 + 107 / 13 * 4) - (729 - 239 / 13 * 4)) / 6 * 2 && Math.Pow(6.383 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(6.583 / 174.24, 1 / -0.802)) map1_4 = map1_4 + col_size;
                        if ((729 - 239 / 13 * 5) + ((903 + 107 / 13 * 5) - (729 - 239 / 13 * 5)) / 6 * 1 < numX && numX < (729 - 239 / 13 * 5) + ((903 + 107 / 13 * 5) - (729 - 239 / 13 * 5)) / 6 * 2 && Math.Pow(5.946 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(6.146 / 174.24, 1 / -0.802)) map1_5 = map1_5 + col_size;
                        if ((729 - 239 / 13 * 6) + ((903 + 107 / 13 * 6) - (729 - 239 / 13 * 6)) / 6 * 1 < numX && numX < (729 - 239 / 13 * 6) + ((903 + 107 / 13 * 6) - (729 - 239 / 13 * 6)) / 6 * 2 && Math.Pow(5.509 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(5.709 / 174.24, 1 / -0.802)) map1_6 = map1_6 + col_size;
                        if ((729 - 239 / 13 * 7) + ((903 + 107 / 13 * 7) - (729 - 239 / 13 * 7)) / 6 * 1 < numX && numX < (729 - 239 / 13 * 7) + ((903 + 107 / 13 * 7) - (729 - 239 / 13 * 7)) / 6 * 2 && Math.Pow(5.072 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(5.272 / 174.24, 1 / -0.802)) map1_7 = map1_7 + col_size;
                        if ((729 - 239 / 13 * 8) + ((903 + 107 / 13 * 8) - (729 - 239 / 13 * 8)) / 6 * 1 < numX && numX < (729 - 239 / 13 * 8) + ((903 + 107 / 13 * 8) - (729 - 239 / 13 * 8)) / 6 * 2 && Math.Pow(4.635 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(4.835 / 174.24, 1 / -0.802)) map1_8 = map1_8 + col_size;
                        if ((729 - 239 / 13 * 9) + ((903 + 107 / 13 * 9) - (729 - 239 / 13 * 9)) / 6 * 1 < numX && numX < (729 - 239 / 13 * 9) + ((903 + 107 / 13 * 9) - (729 - 239 / 13 * 9)) / 6 * 2 && Math.Pow(4.198 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(4.398 / 174.24, 1 / -0.802)) map1_9 = map1_9 + col_size;
                        if ((729 - 239 / 13 * 10) + ((903 + 107 / 13 * 10) - (729 - 239 / 13 * 10)) / 6 * 1 < numX && numX < (729 - 239 / 34 * 10) + ((903 + 107 / 34 * 10) - (729 - 239 / 13 * 10)) / 6 * 2 && Math.Pow(3.761 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(3.961 / 174.24, 1 / -0.802)) map1_10 = map1_10 + col_size;
                        if ((729 - 239 / 13 * 11) + ((903 + 107 / 13 * 11) - (729 - 239 / 13 * 11)) / 6 * 1 < numX && numX < (729 - 239 / 34 * 11) + ((903 + 107 / 34 * 11) - (729 - 239 / 13 * 11)) / 6 * 2 && Math.Pow(3.324 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(3.524 / 174.24, 1 / -0.802)) map1_11 = map1_11 + col_size;
                        if ((729 - 239 / 13 * 12) + ((903 + 107 / 13 * 12) - (729 - 239 / 13 * 12)) / 6 * 1 < numX && numX < (729 - 239 / 34 * 12) + ((903 + 107 / 34 * 12) - (729 - 239 / 13 * 12)) / 6 * 2 && Math.Pow(2.887 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(3.087 / 174.24, 1 / -0.802)) map1_12 = map1_12 + col_size;
                        if ((729 - 239 / 13 * 13) + ((903 + 107 / 13 * 13) - (729 - 239 / 13 * 13)) / 6 * 1 < numX && numX < (729 - 239 / 34 * 13) + ((903 + 107 / 34 * 13) - (729 - 239 / 13 * 13)) / 6 * 2 && Math.Pow(2.45 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(2.65 / 174.24, 1 / -0.802)) map1_13 = map1_13 + col_size;


                        //3dan

                        if (729 + (903 - 729) / 6 * 2 < numX && numX < 729 + (903 - 729) / 6 * 3 && Math.Pow(8.131 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(8.331 / 174.24, 1 / -0.802)) map2_0 = map2_0 + col_size;
                        if ((729 - 239 / 13 * 1) + ((903 + 107 / 13 * 1) - (729 - 239 / 13 * 1)) / 6 * 2 < numX && numX < (729 - 239 / 13 * 1) + ((903 + 107 / 13 * 1) - (729 - 239 / 13 * 1)) / 6 * 3 && Math.Pow(7.694 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(7.894 / 174.24, 1 / -0.802)) map2_1 = map2_1 + col_size;
                        if ((729 - 239 / 13 * 2) + ((903 + 107 / 13 * 2) - (729 - 239 / 13 * 2)) / 6 * 2 < numX && numX < (729 - 239 / 13 * 2) + ((903 + 107 / 13 * 2) - (729 - 239 / 13 * 2)) / 6 * 3 && Math.Pow(7.257 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(7.457 / 174.24, 1 / -0.802)) map2_2 = map2_2 + col_size;
                        if ((729 - 239 / 13 * 3) + ((903 + 107 / 13 * 3) - (729 - 239 / 13 * 3)) / 6 * 2 < numX && numX < (729 - 239 / 13 * 3) + ((903 + 107 / 13 * 3) - (729 - 239 / 13 * 3)) / 6 * 3 && Math.Pow(6.82 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(7.02 / 174.24, 1 / -0.802)) map2_3 = map2_3 + col_size;
                        if ((729 - 239 / 13 * 4) + ((903 + 107 / 13 * 4) - (729 - 239 / 13 * 4)) / 6 * 2 < numX && numX < (729 - 239 / 13 * 4) + ((903 + 107 / 13 * 4) - (729 - 239 / 13 * 4)) / 6 * 3 && Math.Pow(6.383 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(6.583 / 174.24, 1 / -0.802)) map2_4 = map2_4 + col_size;
                        if ((729 - 239 / 13 * 5) + ((903 + 107 / 13 * 5) - (729 - 239 / 13 * 5)) / 6 * 2 < numX && numX < (729 - 239 / 13 * 5) + ((903 + 107 / 13 * 5) - (729 - 239 / 13 * 5)) / 6 * 3 && Math.Pow(5.946 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(6.146 / 174.24, 1 / -0.802)) map2_5 = map2_5 + col_size;
                        if ((729 - 239 / 13 * 6) + ((903 + 107 / 13 * 6) - (729 - 239 / 13 * 6)) / 6 * 2 < numX && numX < (729 - 239 / 13 * 6) + ((903 + 107 / 13 * 6) - (729 - 239 / 13 * 6)) / 6 * 3 && Math.Pow(5.509 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(5.709 / 174.24, 1 / -0.802)) map2_6 = map2_6 + col_size;
                        if ((729 - 239 / 13 * 7) + ((903 + 107 / 13 * 7) - (729 - 239 / 13 * 7)) / 6 * 2 < numX && numX < (729 - 239 / 13 * 7) + ((903 + 107 / 13 * 7) - (729 - 239 / 13 * 7)) / 6 * 3 && Math.Pow(5.072 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(5.272 / 174.24, 1 / -0.802)) map2_7 = map2_7 + col_size;
                        if ((729 - 239 / 13 * 8) + ((903 + 107 / 13 * 8) - (729 - 239 / 13 * 8)) / 6 * 2 < numX && numX < (729 - 239 / 13 * 8) + ((903 + 107 / 13 * 8) - (729 - 239 / 13 * 8)) / 6 * 3 && Math.Pow(4.635 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(4.835 / 174.24, 1 / -0.802)) map2_8 = map2_8 + col_size;
                        if ((729 - 239 / 13 * 9) + ((903 + 107 / 13 * 9) - (729 - 239 / 13 * 9)) / 6 * 2 < numX && numX < (729 - 239 / 13 * 9) + ((903 + 107 / 13 * 9) - (729 - 239 / 13 * 9)) / 6 * 3 && Math.Pow(4.198 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(4.398 / 174.24, 1 / -0.802)) map2_9 = map2_9 + col_size;
                        if ((729 - 239 / 13 * 10) + ((903 + 107 / 13 * 10) - (729 - 239 / 13 * 10)) / 6* 2 < numX && numX < (729 - 239 / 13 * 10) + ((903 + 107 / 13 * 10) - (729 - 239 / 13 * 10)) / 6 * 3 && Math.Pow(3.761 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(3.961 / 174.24, 1 / -0.802)) map2_10 = map2_10 + col_size;
                        if ((729 - 239 / 13 * 11) + ((903 + 107 / 13 * 11) - (729 - 239 / 13 * 11)) / 6 * 2 < numX && numX < (729 - 239 / 13 * 11) + ((903 + 107 / 13 * 11) - (729 - 239 / 13 * 11)) / 6 * 3 && Math.Pow(3.324 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(3.524 / 174.24, 1 / -0.802)) map2_11 = map2_11 + col_size;
                        if ((729 - 239 / 13 * 12) + ((903 + 107 / 13 * 12) - (729 - 239 / 13 * 12)) / 6 * 2 < numX && numX < (729 - 239 / 13 * 12) + ((903 + 107 / 13 * 12) - (729 - 239 / 13 * 12)) / 6 * 3 && Math.Pow(2.887 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(3.087 / 174.24, 1 / -0.802)) map2_12 = map2_12 + col_size;
                        if ((729 - 239 / 13 * 13) + ((903 + 107 / 13 * 13) - (729 - 239 / 13 * 13)) / 6 * 2 < numX && numX < (729 - 239 / 13 * 13) + ((903 + 107 / 13 * 13) - (729 - 239 / 13 * 13)) / 6 * 3 && Math.Pow(2.45 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(2.65 / 174.24, 1 / -0.802)) map2_13 = map2_13 + col_size;


                        //4dan

                        if (729 + (903 - 729) / 6 * 3 < numX && numX < 729 + (903 - 729) / 6 * 4 && Math.Pow(8.131 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(8.331 / 174.24, 1 / -0.802)) map3_0 = map3_0 + col_size;
                        if ((729 - 239 / 13 * 1) + ((903 + 107 / 13 * 1) - (729 - 239 / 13 * 1)) / 6 * 3 < numX && numX < (729 - 239 / 13 * 1) + ((903 + 107 / 13 * 1) - (729 - 239 / 13 * 1)) / 6 * 4 && Math.Pow(7.694 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(7.894 / 174.24, 1 / -0.802)) map3_1 = map3_1 + col_size;
                        if ((729 - 239 / 13 * 2) + ((903 + 107 / 13 * 2) - (729 - 239 / 13 * 2)) / 6 * 3 < numX && numX < (729 - 239 / 13 * 2) + ((903 + 107 / 13 * 2) - (729 - 239 / 13 * 2)) / 6 * 4 && Math.Pow(7.257 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(7.457 / 174.24, 1 / -0.802)) map3_2 = map3_2 + col_size;
                        if ((729 - 239 / 13 * 3) + ((903 + 107 / 13 * 3) - (729 - 239 / 13 * 3)) / 6 * 3 < numX && numX < (729 - 239 / 13 * 3) + ((903 + 107 / 13 * 3) - (729 - 239 / 13 * 3)) / 6 * 4 && Math.Pow(6.82 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(7.02 / 174.24, 1 / -0.802)) map3_3 = map3_3 + col_size;
                        if ((729 - 239 / 13 * 4) + ((903 + 107 / 13 * 4) - (729 - 239 / 13 * 4)) / 6 * 3 < numX && numX < (729 - 239 / 13 * 4) + ((903 + 107 / 13 * 4) - (729 - 239 / 13 * 4)) / 6 * 4 && Math.Pow(6.383 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(6.583 / 174.24, 1 / -0.802)) map3_4 = map3_4 + col_size;
                        if ((729 - 239 / 13 * 5) + ((903 + 107 / 13 * 5) - (729 - 239 / 13 * 5)) / 6 * 3 < numX && numX < (729 - 239 / 13 * 5) + ((903 + 107 / 13 * 5) - (729 - 239 / 13 * 5)) / 6 * 4 && Math.Pow(5.946 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(6.146 / 174.24, 1 / -0.802)) map3_5 = map3_5 + col_size;
                        if ((729 - 239 / 13 * 6) + ((903 + 107 / 13 * 6) - (729 - 239 / 13 * 6)) / 6 * 3 < numX && numX < (729 - 239 / 13 * 6) + ((903 + 107 / 13 * 6) - (729 - 239 / 13 * 6)) / 6 * 4 && Math.Pow(5.509 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(5.709 / 174.24, 1 / -0.802)) map3_6 = map3_6 + col_size;
                        if ((729 - 239 / 13 * 7) + ((903 + 107 / 13 * 7) - (729 - 239 / 13 * 7)) / 6 * 3 < numX && numX < (729 - 239 / 13 * 7) + ((903 + 107 / 13 * 7) - (729 - 239 / 13 * 7)) / 6 * 4 && Math.Pow(5.072 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(5.272 / 174.24, 1 / -0.802)) map3_7 = map3_7 + col_size;
                        if ((729 - 239 / 13 * 8) + ((903 + 107 / 13 * 8) - (729 - 239 / 13 * 8)) / 6 * 3 < numX && numX < (729 - 239 / 13 * 8) + ((903 + 107 / 13 * 8) - (729 - 239 / 13 * 8)) / 6 * 4 && Math.Pow(4.635 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(4.835 / 174.24, 1 / -0.802)) map3_8 = map3_8 + col_size;
                        if ((729 - 239 / 13 * 9) + ((903 + 107 / 13 * 9) - (729 - 239 / 13 * 9)) / 6 * 3 < numX && numX < (729 - 239 / 13 * 9) + ((903 + 107 /13 * 9) - (729 - 239 / 13 * 9)) / 6 * 4 && Math.Pow(4.198 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(4.398 / 174.24, 1 / -0.802)) map3_9 = map3_9 + col_size;
                        if ((729 - 239 / 13 * 10) + ((903 + 107 / 13 * 10) - (729 - 239 / 13 * 10)) / 6 * 3 < numX && numX < (729 - 239 / 13 * 10) + ((903 + 107 / 13 * 10) - (729 - 239 / 13 * 10)) / 6 * 4 && Math.Pow(3.761 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(3.961 / 174.24, 1 / -0.802)) map3_10 = map3_10 + col_size;
                        if ((729 - 239 / 13 * 11) + ((903 + 107 / 13 * 11) - (729 - 239 / 13 * 11)) / 6 * 3 < numX && numX < (729 - 239 / 13 * 11) + ((903 + 107 / 13 * 11) - (729 - 239 / 13 * 11)) / 6 * 4 && Math.Pow(3.324 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(3.524 / 174.24, 1 / -0.802)) map3_11 = map3_11 + col_size;
                        if ((729 - 239 / 13 * 12) + ((903 + 107 / 13 * 12) - (729 - 239 / 13 * 12)) / 6 * 3 < numX && numX < (729 - 239 / 13 * 12) + ((903 + 107 / 13 * 12) - (729 - 239 / 13 * 12)) / 6 * 4 && Math.Pow(2.887 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(3.087 / 174.24, 1 / -0.802)) map3_12 = map3_12 + col_size;
                        if ((729 - 239 / 13 * 13) + ((903 + 107 / 13 * 13) - (729 - 239 / 13 * 13)) / 6 * 3 < numX && numX < (729 - 239 / 13 * 13) + ((903 + 107 / 13 * 13) - (729 - 239 / 13 * 13)) / 6 * 4 && Math.Pow(2.45 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(2.65 / 174.24, 1 / -0.802)) map3_13 = map3_13 + col_size;

                        //5dan

                        if (729 + (903 - 729) / 6 * 4 < numX && numX < 729 + (903 - 729) / 6 * 5 && Math.Pow(8.131 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(8.331 / 174.24, 1 / -0.802)) map4_0 = map4_0 + col_size;
                        if ((729 - 239 / 13 * 1) + ((903 + 107 / 13 * 1) - (729 - 239 / 13 * 1)) / 6 * 4 < numX && numX < (729 - 239 / 13 * 1) + ((903 + 107 / 13 * 1) - (729 - 239 / 13 * 1)) / 6 * 5 && Math.Pow(7.694 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(7.894 / 174.24, 1 / -0.802)) map4_1 = map4_1 + col_size;
                        if ((729 - 239 / 13 * 2) + ((903 + 107 / 13 * 2) - (729 - 239 / 13 * 2)) / 6 * 4 < numX && numX < (729 - 239 / 13 * 2) + ((903 + 107 / 13 * 2) - (729 - 239 / 13 * 2)) / 6 * 5 && Math.Pow(7.257 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(7.457 / 174.24, 1 / -0.802)) map4_2 = map4_2 + col_size;
                        if ((729 - 239 / 13 * 3) + ((903 + 107 / 13 * 3) - (729 - 239 / 13 * 3)) / 6 * 4 < numX && numX < (729 - 239 / 13 * 3) + ((903 + 107 / 13 * 3) - (729 - 239 / 13 * 3)) / 6 * 5 && Math.Pow(6.82 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(7.02 / 174.24, 1 / -0.802)) map4_3 = map4_3 + col_size;
                        if ((729 - 239 / 13 * 4) + ((903 + 107 / 13 * 4) - (729 - 239 / 13 * 4)) / 6 * 4 < numX && numX < (729 - 239 / 13 * 4) + ((903 + 107 / 13 * 4) - (729 - 239 / 13 * 4)) / 6 * 5 && Math.Pow(6.383 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(6.583 / 174.24, 1 / -0.802)) map4_4 = map4_4 + col_size;
                        if ((729 - 239 / 13 * 5) + ((903 + 107 / 13 * 5) - (729 - 239 / 13 * 5)) / 6 * 4 < numX && numX < (729 - 239 / 13 * 5) + ((903 + 107 / 13 * 5) - (729 - 239 / 13 * 5)) / 6 * 5 && Math.Pow(5.946 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(6.146 / 174.24, 1 / -0.802)) map4_5 = map4_5 + col_size;
                        if ((729 - 239 / 13 * 6) + ((903 + 107 / 13 * 6) - (729 - 239 / 13 * 6)) / 6 * 4 < numX && numX < (729 - 239 / 13 * 6) + ((903 + 107 / 13 * 6) - (729 - 239 / 13 * 6)) / 6 * 5 && Math.Pow(5.509 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(5.709 / 174.24, 1 / -0.802)) map4_6 = map4_6 + col_size;
                        if ((729 - 239 / 13 * 7) + ((903 + 107 / 13 * 7) - (729 - 239 / 13 * 7)) / 6 * 4 < numX && numX < (729 - 239 / 13 * 7) + ((903 + 107 / 13 * 7) - (729 - 239 / 13 * 7)) / 6 * 5 && Math.Pow(5.072 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(5.272 / 174.24, 1 / -0.802)) map4_7 = map4_7 + col_size;
                        if ((729 - 239 / 13 * 8) + ((903 + 107 / 13 * 8) - (729 - 239 / 13 * 8)) /6 * 4 < numX && numX < (729 - 239 / 13 * 8) + ((903 + 107 / 13 * 8) - (729 - 239 / 13 * 8)) / 6 * 5 && Math.Pow(4.635 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(4.835 / 174.24, 1 / -0.802)) map4_8 = map4_8 + col_size;
                        if ((729 - 239 / 13 * 9) + ((903 + 107 / 13 * 9) - (729 - 239 / 13 * 9)) / 6 * 4 < numX && numX < (729 - 239 / 13 * 9) + ((903 + 107 / 13 * 9) - (729 - 239 / 13 * 9)) / 6 * 5 && Math.Pow(4.198 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(4.398 / 174.24, 1 / -0.802)) map4_9 = map4_9 + col_size;
                        if ((729 - 239 / 13 * 10) + ((903 + 107 / 13 * 10) - (729 - 239 / 13 * 10)) / 6 * 4 < numX && numX < (729 - 239 / 13 * 10) + ((903 + 107 / 13 * 10) - (729 - 239 / 13 * 10)) / 6 * 5 && Math.Pow(3.761 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(3.961 / 174.24, 1 / -0.802)) map4_10 = map4_10 + col_size;
                        if ((729 - 239 / 13 * 11) + ((903 + 107 / 13 * 11) - (729 - 239 / 13 * 11)) / 6 * 4 < numX && numX < (729 - 239 / 13 * 11) + ((903 + 107 / 13 * 11) - (729 - 239 / 13 * 11)) / 6 * 5 && Math.Pow(3.324 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(3.524 / 174.24, 1 / -0.802)) map4_11 = map4_11 + col_size;
                        if ((729 - 239 / 13 * 12) + ((903 + 107 / 13 * 12) - (729 - 239 / 13 * 12)) / 6 * 4 < numX && numX < (729 - 239 / 13 * 12) + ((903 + 107 / 13 * 12) - (729 - 239 / 13 * 12)) / 6 * 5 && Math.Pow(2.887 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(3.087 / 174.24, 1 / -0.802)) map4_12 = map4_12 + col_size;
                        if ((729 - 239 / 13 * 13) + ((903 + 107 / 13 * 13) - (729 - 239 / 13 * 13)) / 6 * 4 < numX && numX < (729 - 239 / 13 * 13) + ((903 + 107 / 13 * 13) - (729 - 239 / 13 * 13)) / 6 * 5 && Math.Pow(2.45 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(2.65 / 174.24, 1 / -0.802)) map4_13 = map4_13 + col_size;

                        //6dan

                        if (729 + (903 - 729) / 6 * 5 < numX && numX < 729 + (903 - 729) / 6 * 6 && Math.Pow(8.131 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(8.331 / 174.24, 1 / -0.802)) map5_0 = map5_0 + col_size;
                        if ((729 - 239 / 13 * 1) + ((903 + 107 / 13 * 1) - (729 - 239 / 13 * 1)) / 6 * 5 < numX && numX < (729 - 239 / 13 * 1) + ((903 + 107 / 13 * 1) - (729 - 239 / 13 * 1)) / 6 * 6 && Math.Pow(7.694 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(7.894 / 174.24, 1 / -0.802)) map5_1 = map5_1 + col_size;
                        if ((729 - 239 / 13 * 2) + ((903 + 107 / 13 * 2) - (729 - 239 / 13 * 2)) / 6* 5 < numX && numX < (729 - 239 / 13 * 2) + ((903 + 107 / 13 * 2) - (729 - 239 / 13 * 2)) / 6 * 6 && Math.Pow(7.257 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(7.457 / 174.24, 1 / -0.802)) map5_2 = map5_2 + col_size;
                        if ((729 - 239 / 13 * 3) + ((903 + 107 / 13 * 3) - (729 - 239 / 13 * 3)) / 6 * 5 < numX && numX < (729 - 239 / 13 * 3) + ((903 + 107 / 13 * 3) - (729 - 239 / 13 * 3)) / 6 * 6 && Math.Pow(6.82 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(7.02 / 174.24, 1 / -0.802)) map5_3 = map5_3 + col_size;
                        if ((729 - 239 / 13 * 4) + ((903 + 107 / 13 * 4) - (729 - 239 / 13 * 4)) / 6 * 5 < numX && numX < (729 - 239 / 13 * 4) + ((903 + 107 / 13 * 4) - (729 - 239 / 13 * 4)) / 6 * 6 && Math.Pow(6.383 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(6.583 / 174.24, 1 / -0.802)) map5_4 = map5_4 + col_size;
                        if ((729 - 239 / 13 * 5) + ((903 + 107 / 13 * 5) - (729 - 239 / 13 * 5)) / 6 * 5 < numX && numX < (729 - 239 / 13 * 5) + ((903 + 107 / 13 * 5) - (729 - 239 / 13 * 5)) / 6 * 6 && Math.Pow(5.946 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(6.146 / 174.24, 1 / -0.802)) map5_5 = map5_5 + col_size;
                        if ((729 - 239 / 13 * 6) + ((903 + 107 / 13 * 6) - (729 - 239 / 13 * 6)) / 6 * 5 < numX && numX < (729 - 239 / 13 * 6) + ((903 + 107 / 13 * 6) - (729 - 239 / 13 * 6)) / 6 * 6 && Math.Pow(5.509 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(5.709 / 174.24, 1 / -0.802)) map5_6 = map5_6 + col_size;
                        if ((729 - 239 / 13 * 7) + ((903 + 107 / 13 * 7) - (729 - 239 / 13 * 7)) / 6 * 5 < numX && numX < (729 - 239 / 13 * 7) + ((903 + 107 / 13 * 7) - (729 - 239 / 13 * 7)) / 6 * 6 && Math.Pow(5.072 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(5.272 / 174.24, 1 / -0.802)) map5_7 = map5_7 + col_size;
                        if ((729 - 239 / 13 * 8) + ((903 + 107 / 13 * 8) - (729 - 239 / 13 * 8)) / 6 * 5 < numX && numX < (729 - 239 / 13 * 8) + ((903 + 107 / 13 * 8) - (729 - 239 / 13 * 8)) / 6 * 6 && Math.Pow(4.635 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(4.835 / 174.24, 1 / -0.802)) map5_8 = map5_8 + col_size;
                        if ((729 - 239 / 13 * 9) + ((903 + 107 / 13 * 9) - (729 - 239 / 13 * 9)) / 6 * 5 < numX && numX < (729 - 239 / 13 * 9) + ((903 + 107 / 13 * 9) - (729 - 239 / 13 * 9)) / 6 * 6 && Math.Pow(4.198 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(4.398 / 174.24, 1 / -0.802)) map5_9 = map5_9 + col_size;
                        if ((729 - 239 / 13 * 10) + ((903 + 107 / 13 * 10) - (729 - 239 / 13 * 10)) / 6 * 5 < numX && numX < (729 - 239 / 13 * 10) + ((903 + 107 / 13 * 10) - (729 - 239 / 13 * 10)) / 6 * 6 && Math.Pow(3.761 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(3.961 / 174.24, 1 / -0.802)) map5_10 = map5_10 + col_size;
                        if ((729 - 239 / 13 * 11) + ((903 + 107 / 13 * 11) - (729 - 239 / 13 * 11)) / 6 * 5 < numX && numX < (729 - 239 / 13 * 11) + ((903 + 107 / 13 * 11) - (729 - 239 / 13 * 11)) / 6 * 6 && Math.Pow(3.324 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(3.524 / 174.24, 1 / -0.802)) map5_11 = map5_11 + col_size;
                        if ((729 - 239 / 13 * 12) + ((903 + 107 / 13 * 12) - (729 - 239 / 13 * 12)) / 6 * 5 < numX && numX < (729 - 239 / 13 * 12) + ((903 + 107 / 13 * 12) - (729 - 239 / 13 * 12)) / 6 * 6 && Math.Pow(2.887 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(3.087 / 174.24, 1 / -0.802)) map5_12 = map5_12 + col_size;
                        if ((729 - 239 / 13 * 13) + ((903 + 107 / 13 * 13) - (729 - 239 / 13 * 13)) / 6 * 5 < numX && numX < (729 - 239 / 13 * 13) + ((903 + 107 / 13 * 13) - (729 - 239 / 13 * 13)) / 6 * 6 && Math.Pow(2.45 / 174.24, 1 / -0.802) > numSize && numSize > Math.Pow(2.65 / 174.24, 1 / -0.802)) map5_13 = map5_13 + col_size;

                      

                        aaa = aaa + 1;
                        respX = respX + json;//aho
                        respY = respY + jsony;//aho
                        respSize = respSize + jsonsize;//aho
                        textBox8.Text = Convert.ToString(aaa);
                    }
                }
                else { respX = "no result"; }
            }
            catch (Exception ex) {
                respX = ex.ToString();
                respY = ex.ToString(); //aho
                respSize = ex.ToString();
            }

            double asws = Math.Pow(8.77 / 174.24, 1 / -0.802);

            // 結果表示
            textBox6.Text = respX;
            textBox7.Text = respY;
            textBox3.Text = respSize;
            textBox2.Text = textBox2.Text + Environment.NewLine + textBox1.Text;
            //textBox4.Text = Convert.ToString(asws);

        }


       /* private void button4_Click_not(object sender, EventArgs e)///Fusion Y
        {
            // Table ID取得
            string tableId = null;

            FusiontablesService fusiontablesService
                = new FusiontablesService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = GetCredential().Result,
                    ApplicationName =null 
                });
            // テーブルの設定
            Table tableData = fusiontablesService.Table.Get(tableId).Execute();

            //select
            string respY = "";
            try
            {
                string sql = "SELECT Y From " + tableId;
                var result = fusiontablesService.Query.SqlGet(sql).Execute();

                int numRow = result.Rows.Count;
                if (numRow > 0)
                {
                    for (int i = 0; i < numRow; i++)
                    {
                        string json = JsonConvert.SerializeObject(result.Rows[i]);

                        json = Regex.Replace(json, @"[^0-9]", " ");
                        int numY = int.Parse(json);
                        textBox8.Text = Convert.ToString(numY);

                        respY = respY + json;

                    }
                }
                else { respY = "no result"; }
            }
            catch (Exception ex) { respY = ex.ToString(); }
            // 結果表示
            textBox7.Text = respY;
        }*/

     /*  public static async Task<UserCredential> GetCredential()
        {
            string jPath = "";

            using (var stream = new FileStream(jPath, FileMode.Open, FileAccess.Read))
            {
               // return await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    //    GoogleClientSecrets.Load(stream).Secrets,
                       // new[] { FusiontablesService.Scope.Fusiontables },
                      //  "mail addres", CancellationToken.None);
            }
        }*/

       

        private void Form1_Load(object sender, EventArgs e)
        {
         //なにもあるかな  
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
