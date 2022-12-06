﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022
{
    internal class Day4
    {
        public static void Run()
        {
            //string input = "2-4,6-8\r\n2-3,4-5\r\n5-7,7-9\r\n2-8,3-7\r\n6-6,4-6\r\n2-6,4-8";
            string input = "24-66,23-25\r\n3-3,2-80\r\n14-80,13-20\r\n39-78,40-40\r\n36-90,89-90\r\n51-94,50-50\r\n10-72,10-98\r\n54-81,2-90\r\n27-84,27-85\r\n21-57,21-57\r\n6-55,4-5\r\n80-87,87-90\r\n23-71,22-90\r\n24-37,2-36\r\n79-91,78-91\r\n75-92,91-93\r\n23-80,23-81\r\n67-94,68-94\r\n79-85,79-81\r\n40-88,39-89\r\n15-75,14-76\r\n18-77,34-78\r\n2-99,4-93\r\n1-74,15-75\r\n39-82,39-81\r\n19-91,18-84\r\n56-87,57-86\r\n15-72,14-71\r\n37-88,36-87\r\n21-24,18-23\r\n34-83,34-34\r\n20-95,94-95\r\n27-75,26-80\r\n91-93,27-92\r\n55-66,56-62\r\n29-31,30-89\r\n85-95,89-99\r\n1-2,1-3\r\n63-64,13-64\r\n66-95,30-86\r\n2-73,3-74\r\n25-99,6-25\r\n10-28,28-87\r\n10-42,9-43\r\n12-46,46-75\r\n91-97,91-96\r\n46-59,46-59\r\n34-35,5-34\r\n27-93,93-93\r\n4-12,21-97\r\n7-65,5-8\r\n42-63,2-62\r\n70-76,64-75\r\n1-95,1-94\r\n12-30,13-30\r\n3-99,2-99\r\n46-60,58-60\r\n1-94,93-98\r\n7-98,8-98\r\n7-51,8-81\r\n39-84,40-85\r\n43-84,8-84\r\n10-93,11-93\r\n3-63,2-47\r\n18-87,18-18\r\n77-96,95-97\r\n2-99,1-99\r\n3-45,2-45\r\n19-99,8-97\r\n7-98,8-60\r\n3-94,2-2\r\n51-71,21-51\r\n28-98,10-27\r\n13-96,13-97\r\n4-99,1-1\r\n3-93,93-97\r\n13-13,14-98\r\n16-38,17-17\r\n16-46,16-46\r\n7-63,4-8\r\n18-85,13-19\r\n17-21,18-21\r\n7-74,8-73\r\n5-77,4-6\r\n11-18,1-18\r\n3-25,4-4\r\n2-96,2-93\r\n19-38,18-39\r\n11-45,10-10\r\n20-20,21-83\r\n2-97,97-97\r\n81-81,2-80\r\n5-82,58-59\r\n47-51,4-47\r\n89-93,40-89\r\n19-29,18-84\r\n18-36,16-18\r\n41-55,47-47\r\n6-34,7-33\r\n5-82,6-81\r\n6-19,18-27\r\n42-55,43-55\r\n1-99,2-71\r\n45-94,45-45\r\n2-88,1-88\r\n15-35,14-36\r\n17-36,10-25\r\n20-96,84-98\r\n81-87,81-81\r\n85-87,85-86\r\n34-74,73-74\r\n17-97,16-98\r\n11-50,12-51\r\n2-99,3-3\r\n79-90,79-91\r\n89-99,1-89\r\n87-93,72-93\r\n31-52,30-96\r\n75-84,45-83\r\n81-96,81-96\r\n84-85,24-85\r\n36-60,35-36\r\n11-91,10-91\r\n18-19,19-62\r\n50-52,50-54\r\n59-86,52-86\r\n61-65,70-70\r\n28-96,58-99\r\n10-46,46-46\r\n10-10,10-25\r\n17-72,18-18\r\n58-77,34-59\r\n3-5,5-34\r\n14-14,14-83\r\n5-88,6-14\r\n2-70,3-69\r\n42-79,48-80\r\n26-48,26-27\r\n15-84,14-85\r\n82-83,33-76\r\n14-34,5-33\r\n27-76,26-26\r\n3-88,2-2\r\n19-58,20-57\r\n26-79,25-89\r\n94-95,13-94\r\n35-77,35-78\r\n63-99,69-99\r\n18-26,27-99\r\n1-76,76-77\r\n37-44,22-44\r\n3-64,3-89\r\n54-86,55-85\r\n92-92,92-95\r\n26-38,26-38\r\n62-81,19-80\r\n20-63,8-65\r\n46-79,46-80\r\n35-71,70-72\r\n12-81,11-11\r\n34-69,18-77\r\n1-84,2-2\r\n19-24,18-21\r\n8-90,89-91\r\n12-64,64-65\r\n18-97,17-19\r\n93-93,5-93\r\n34-46,34-46\r\n14-82,13-81\r\n32-46,46-47\r\n1-8,9-97\r\n3-4,3-54\r\n85-87,69-86\r\n12-90,12-91\r\n7-11,10-33\r\n19-34,18-24\r\n36-63,26-62\r\n4-98,6-98\r\n80-96,80-81\r\n10-11,10-34\r\n21-69,8-70\r\n6-80,5-81\r\n14-92,3-15\r\n23-40,16-39\r\n8-66,20-66\r\n12-79,12-13\r\n14-61,15-52\r\n10-29,10-29\r\n36-37,36-89\r\n46-48,18-47\r\n24-98,23-25\r\n81-96,13-81\r\n6-88,1-89\r\n58-76,57-75\r\n56-76,57-75\r\n1-84,1-1\r\n1-20,2-20\r\n38-98,38-99\r\n33-73,32-73\r\n41-95,40-94\r\n29-44,28-44\r\n68-86,67-69\r\n1-66,1-2\r\n12-28,13-90\r\n28-74,19-29\r\n48-51,51-65\r\n11-64,11-64\r\n74-74,66-74\r\n2-5,5-87\r\n69-69,4-69\r\n21-51,51-56\r\n51-83,13-83\r\n12-99,5-6\r\n3-91,4-90\r\n3-55,8-36\r\n12-44,36-45\r\n6-86,5-87\r\n9-18,8-16\r\n13-63,14-57\r\n3-96,4-95\r\n41-87,42-86\r\n44-62,22-48\r\n17-62,46-63\r\n62-63,63-64\r\n31-59,30-60\r\n10-78,9-79\r\n41-97,20-96\r\n18-92,18-92\r\n30-30,30-90\r\n6-80,4-79\r\n46-98,13-36\r\n7-70,7-7\r\n35-46,25-46\r\n77-77,76-76\r\n8-10,9-78\r\n4-98,5-36\r\n37-96,41-96\r\n35-68,34-88\r\n22-69,40-70\r\n13-90,12-89\r\n11-39,12-56\r\n51-82,50-81\r\n47-96,46-73\r\n95-96,2-91\r\n66-95,56-77\r\n84-84,83-85\r\n7-58,8-87\r\n6-83,5-83\r\n23-49,14-48\r\n4-97,5-96\r\n17-18,17-46\r\n15-76,93-99\r\n63-64,63-67\r\n45-46,29-45\r\n29-84,13-84\r\n95-95,95-98\r\n19-91,11-37\r\n14-19,19-94\r\n24-93,75-91\r\n52-79,78-80\r\n3-94,4-93\r\n2-99,2-3\r\n40-96,38-95\r\n23-91,23-91\r\n88-89,66-88\r\n14-92,91-92\r\n14-94,6-94\r\n21-57,36-84\r\n15-97,99-99\r\n2-98,1-99\r\n38-80,38-80\r\n12-93,29-98\r\n19-34,20-42\r\n11-70,10-71\r\n44-95,45-95\r\n53-69,54-68\r\n33-68,10-34\r\n33-35,33-34\r\n3-5,4-66\r\n57-82,56-56\r\n36-54,36-53\r\n14-15,10-15\r\n24-51,38-52\r\n16-76,72-76\r\n56-57,3-57\r\n6-89,5-90\r\n12-45,13-70\r\n36-38,37-88\r\n19-31,25-31\r\n2-2,8-96\r\n5-92,4-69\r\n9-98,8-8\r\n5-14,5-14\r\n46-99,9-46\r\n55-56,2-55\r\n7-95,7-94\r\n45-65,41-65\r\n80-81,4-80\r\n6-47,48-86\r\n25-34,35-75\r\n72-74,71-71\r\n2-94,1-3\r\n31-49,32-49\r\n20-61,19-35\r\n11-86,11-90\r\n52-78,52-53\r\n42-42,18-43\r\n2-2,4-94\r\n8-78,78-78\r\n3-49,2-50\r\n5-74,11-73\r\n17-56,16-72\r\n46-87,47-79\r\n72-80,47-51\r\n11-69,12-12\r\n2-99,3-99\r\n13-27,12-15\r\n23-95,22-96\r\n39-41,40-96\r\n74-98,73-73\r\n82-83,80-82\r\n12-79,11-32\r\n6-58,7-7\r\n3-3,3-97\r\n4-97,24-95\r\n3-80,4-75\r\n72-83,71-84\r\n20-82,21-21\r\n6-73,6-72\r\n77-77,77-97\r\n18-57,57-57\r\n53-76,46-75\r\n21-40,20-74\r\n60-65,55-64\r\n78-78,32-78\r\n22-46,42-46\r\n4-46,3-47\r\n35-39,39-40\r\n79-90,80-89\r\n36-36,37-60\r\n9-28,13-29\r\n15-85,82-85\r\n5-5,4-79\r\n17-86,9-17\r\n6-57,57-57\r\n76-88,76-88\r\n73-79,78-80\r\n52-54,2-53\r\n1-95,6-94\r\n46-91,23-99\r\n70-86,11-71\r\n19-96,18-96\r\n25-42,24-24\r\n32-88,88-94\r\n7-93,8-99\r\n5-21,5-20\r\n34-94,93-94\r\n92-93,15-92\r\n38-84,39-85\r\n79-80,7-79\r\n48-72,72-72\r\n10-92,93-98\r\n14-53,15-92\r\n7-42,7-37\r\n11-88,11-87\r\n41-65,64-65\r\n71-85,11-64\r\n21-79,79-87\r\n80-81,22-81\r\n40-79,39-41\r\n18-67,67-91\r\n11-13,12-61\r\n1-97,96-98\r\n5-66,4-4\r\n1-1,2-75\r\n15-62,16-62\r\n28-56,28-28\r\n3-3,4-79\r\n68-94,3-68\r\n8-92,7-9\r\n69-83,69-84\r\n6-90,22-90\r\n10-20,5-10\r\n21-80,20-21\r\n15-76,14-76\r\n75-75,74-83\r\n5-13,6-22\r\n39-84,83-84\r\n30-43,34-38\r\n42-98,43-97\r\n6-29,5-59\r\n62-80,63-88\r\n5-93,6-6\r\n53-64,54-64\r\n47-47,4-47\r\n62-62,59-62\r\n46-87,46-87\r\n93-95,43-55\r\n4-4,4-19\r\n86-91,48-86\r\n22-45,23-44\r\n13-38,38-93\r\n5-36,4-20\r\n27-27,27-33\r\n10-12,11-83\r\n10-93,3-93\r\n79-80,35-80\r\n64-90,53-68\r\n52-91,47-89\r\n2-66,2-3\r\n58-58,22-57\r\n7-58,5-94\r\n3-11,4-10\r\n32-38,31-39\r\n10-76,21-29\r\n15-42,15-42\r\n9-43,9-95\r\n3-56,4-57\r\n35-68,36-68\r\n55-89,56-88\r\n2-3,2-99\r\n2-97,97-99\r\n29-66,30-65\r\n5-25,4-25\r\n52-87,51-54\r\n28-64,36-66\r\n52-90,51-51\r\n95-96,33-95\r\n1-2,1-82\r\n19-32,20-31\r\n73-75,74-83\r\n73-87,87-88\r\n19-70,70-70\r\n4-93,5-13\r\n96-96,6-95\r\n10-17,10-18\r\n70-73,24-70\r\n25-25,26-76\r\n58-58,10-58\r\n5-83,4-84\r\n45-47,46-74\r\n50-67,66-68\r\n88-89,89-93\r\n15-19,16-24\r\n28-30,2-29\r\n17-19,18-77\r\n21-94,21-83\r\n23-81,81-82\r\n2-91,3-66\r\n75-94,76-94\r\n2-4,3-99\r\n19-82,82-83\r\n3-85,3-3\r\n62-74,45-61\r\n33-33,33-47\r\n66-72,66-72\r\n62-97,61-61\r\n41-74,40-75\r\n7-89,4-7\r\n56-67,55-57\r\n6-25,25-89\r\n11-11,10-14\r\n89-98,16-97\r\n18-76,18-76\r\n23-96,61-97\r\n6-15,16-68\r\n3-99,2-99\r\n22-61,9-22\r\n45-86,44-44\r\n30-46,45-46\r\n55-86,1-97\r\n21-95,20-95\r\n20-47,48-82\r\n15-47,16-80\r\n39-51,39-52\r\n9-15,9-90\r\n1-86,85-86\r\n38-38,38-79\r\n41-41,18-42\r\n7-98,87-98\r\n9-87,60-88\r\n30-87,87-88\r\n10-58,1-6\r\n5-58,5-58\r\n38-76,37-76\r\n9-82,81-82\r\n2-10,5-43\r\n50-51,2-51\r\n35-93,34-93\r\n18-75,17-75\r\n14-59,14-59\r\n27-27,28-88\r\n61-62,46-61\r\n38-74,38-51\r\n49-87,50-50\r\n39-39,38-95\r\n48-98,2-97\r\n27-29,28-92\r\n23-55,22-54\r\n30-31,29-31\r\n11-59,10-58\r\n15-84,59-85\r\n22-57,24-56\r\n17-42,6-42\r\n5-93,92-94\r\n76-89,76-90\r\n1-84,84-85\r\n36-77,13-78\r\n31-78,31-57\r\n23-89,22-90\r\n36-37,36-48\r\n41-84,34-83\r\n6-36,5-6\r\n74-91,45-92\r\n62-99,62-65\r\n3-30,4-98\r\n9-83,9-83\r\n11-93,13-94\r\n7-35,6-6\r\n36-38,37-67\r\n84-93,1-92\r\n28-57,27-56\r\n94-97,95-98\r\n41-74,40-75\r\n7-91,12-88\r\n42-97,43-96\r\n7-13,14-85\r\n58-96,4-98\r\n15-95,47-95\r\n87-90,5-87\r\n35-71,36-71\r\n27-29,29-29\r\n21-28,28-46\r\n2-13,13-99\r\n38-52,39-51\r\n12-79,61-80\r\n59-81,19-59\r\n87-88,15-87\r\n10-53,8-10\r\n4-10,2-9\r\n13-93,69-94\r\n42-61,82-83\r\n9-97,10-10\r\n9-21,8-20\r\n42-89,89-90\r\n4-86,79-87\r\n11-58,11-47\r\n83-84,14-84\r\n5-75,32-75\r\n45-97,97-97\r\n39-39,38-48\r\n44-44,43-58\r\n50-69,49-68\r\n61-87,55-86\r\n4-95,94-95\r\n47-48,47-48\r\n40-67,39-39\r\n15-68,15-69\r\n4-84,4-84\r\n98-99,1-99\r\n3-8,8-98\r\n2-97,3-97\r\n20-46,46-90\r\n25-64,43-83\r\n26-47,26-47\r\n27-28,1-28\r\n50-52,51-64\r\n76-87,91-99\r\n39-60,38-40\r\n3-99,4-99\r\n67-82,10-67\r\n45-76,46-59\r\n16-79,15-78\r\n11-63,19-62\r\n9-54,10-55\r\n4-95,96-96\r\n16-87,15-88\r\n9-30,29-88\r\n68-69,10-68\r\n51-54,52-74\r\n2-4,4-59\r\n1-96,97-99\r\n17-90,54-91\r\n25-27,26-88\r\n95-97,57-95\r\n25-33,25-25\r\n33-64,33-47\r\n32-93,33-93\r\n3-37,37-38\r\n60-80,54-79\r\n38-39,21-39\r\n9-94,94-96\r\n27-80,27-81\r\n1-74,22-75\r\n11-89,11-89\r\n7-81,82-98\r\n5-56,56-75\r\n3-3,3-90\r\n18-62,18-19\r\n28-99,29-98\r\n2-2,2-75\r\n31-86,12-65\r\n71-72,20-71\r\n73-73,56-72\r\n94-98,7-88\r\n91-91,92-92\r\n3-98,4-97\r\n2-71,70-71\r\n5-63,63-63\r\n39-81,21-81\r\n44-44,44-78\r\n64-88,15-87\r\n95-95,92-96\r\n17-32,32-94\r\n11-81,12-82\r\n86-97,85-98\r\n92-99,8-98\r\n22-70,23-23\r\n11-97,10-11\r\n72-73,61-72\r\n25-58,24-98\r\n52-65,53-55\r\n66-67,1-66\r\n8-65,53-65\r\n83-98,82-89\r\n33-79,33-79\r\n65-79,65-92\r\n7-34,8-53\r\n27-43,34-73\r\n28-77,28-77\r\n59-96,27-98\r\n7-55,19-66\r\n2-78,3-79\r\n13-13,12-81\r\n2-92,91-92\r\n2-44,1-43\r\n32-33,32-99\r\n92-93,20-93\r\n97-98,8-98\r\n15-60,16-60\r\n3-98,2-99\r\n37-37,13-37\r\n9-82,82-97\r\n23-86,22-67\r\n18-35,9-27\r\n57-73,57-58\r\n36-93,36-37\r\n15-15,15-77\r\n52-82,51-73\r\n13-22,14-96\r\n9-67,8-68\r\n6-76,7-83\r\n1-4,1-4\r\n1-95,1-90\r\n25-29,29-80\r\n77-91,39-90\r\n7-97,8-96\r\n45-77,46-88\r\n20-59,59-82\r\n64-64,63-96\r\n31-83,32-32\r\n11-96,96-97\r\n59-77,59-59\r\n47-75,47-65\r\n8-95,2-8\r\n19-81,19-81\r\n35-36,36-37\r\n83-84,83-90\r\n4-97,2-49\r\n39-96,38-97\r\n64-99,6-86\r\n29-95,29-96\r\n27-84,7-27\r\n4-63,6-62\r\n60-66,61-66\r\n58-91,90-91\r\n44-65,62-69\r\n13-24,23-61\r\n45-88,88-93\r\n62-95,95-96\r\n1-86,1-85\r\n33-33,12-33\r\n36-67,37-66\r\n11-49,48-50\r\n4-76,1-4\r\n5-84,4-53\r\n22-65,22-65\r\n12-22,13-64\r\n16-16,16-33\r\n10-97,44-98\r\n47-52,48-64\r\n58-95,59-99\r\n18-71,37-72\r\n7-79,8-79\r\n2-61,3-98\r\n67-84,83-85\r\n56-86,82-85\r\n22-97,28-98\r\n42-57,41-57\r\n23-26,11-25\r\n45-82,5-81\r\n41-43,42-79\r\n3-93,93-93\r\n60-87,59-84\r\n93-99,44-93\r\n47-95,74-95\r\n51-52,40-52\r\n11-32,12-84\r\n4-89,1-4\r\n3-93,93-94\r\n97-97,17-96\r\n12-67,11-11\r\n25-80,39-60\r\n98-99,3-98\r\n61-62,60-62\r\n24-35,34-35\r\n10-86,11-87\r\n64-66,4-90\r\n1-1,2-89\r\n15-75,46-76\r\n71-72,17-72\r\n7-9,8-91\r\n18-36,18-70\r\n3-5,4-16\r\n8-88,7-88\r\n69-85,69-69\r\n17-46,18-47\r\n8-37,37-50\r\n2-38,1-39\r\n99-99,9-99\r\n30-78,31-89\r\n51-64,52-63\r\n11-99,1-99\r\n81-82,23-81\r\n54-62,53-53\r\n80-91,24-80\r\n96-98,75-97\r\n78-78,46-78\r\n7-88,7-89\r\n1-22,1-22\r\n5-39,5-38\r\n95-95,13-96\r\n19-49,17-85\r\n7-96,6-96\r\n29-93,49-75\r\n42-76,43-75\r\n62-62,61-70\r\n36-42,37-46\r\n5-84,91-92\r\n26-95,25-27\r\n36-81,63-82\r\n17-51,18-50\r\n34-74,34-75\r\n6-53,53-86\r\n28-28,28-36\r\n6-6,6-77\r\n42-70,41-70\r\n29-92,92-93\r\n10-50,9-51\r\n90-93,80-90\r\n3-84,28-97\r\n3-3,2-74\r\n9-92,8-10\r\n58-70,58-70\r\n1-61,2-16\r\n29-85,29-69\r\n61-96,31-96\r\n30-81,12-30\r\n25-72,24-26\r\n60-96,60-96\r\n2-29,2-28\r\n27-57,26-57\r\n5-94,2-99\r\n5-15,4-19\r\n2-46,3-29\r\n39-60,38-99\r\n1-2,1-83\r\n17-86,18-87\r\n68-95,69-94\r\n31-52,8-53\r\n80-89,81-88\r\n17-57,16-56\r\n7-28,6-24\r\n35-63,63-63\r\n42-89,88-89\r\n97-98,71-98\r\n79-82,6-68\r\n8-34,34-34\r\n66-71,38-70\r\n15-65,66-71\r\n22-82,21-83\r\n9-81,10-22\r\n19-85,18-86\r\n19-19,20-70\r\n6-76,45-76\r\n1-37,36-55\r\n49-98,98-98\r\n9-88,4-10\r\n74-83,17-82\r\n30-63,22-62\r\n8-89,4-8\r\n3-87,2-16\r\n91-91,49-91\r\n2-53,53-97\r\n9-14,13-71\r\n33-98,34-99\r\n31-58,27-59\r\n22-34,34-34\r\n3-5,4-97\r\n36-93,25-31\r\n50-62,35-61\r\n43-84,43-83\r\n60-81,19-60\r\n2-90,2-89\r\n1-3,5-44\r\n5-99,8-96\r\n7-7,8-8\r\n27-39,28-80\r\n6-89,4-5\r\n44-66,11-67\r\n15-88,7-99\r\n5-44,5-6\r\n70-95,71-94\r\n2-2,2-81\r\n99-99,4-99\r\n98-99,22-98\r\n69-78,65-77\r\n46-51,45-51\r\n34-67,66-68\r\n36-74,35-75\r\n38-63,39-62\r\n22-72,39-73\r\n15-52,16-52\r\n19-98,19-97\r\n4-99,3-3\r\n2-2,3-96\r\n3-85,4-4\r\n19-91,10-20\r\n4-20,20-78\r\n2-56,6-85\r\n6-54,5-54\r\n4-65,5-65\r\n13-74,15-74\r\n78-92,79-94\r\n68-77,62-76\r\n5-75,5-75\r\n68-85,69-88\r\n62-94,21-94\r\n6-94,5-95\r\n1-3,3-61\r\n37-68,37-69\r\n4-4,5-65\r\n96-97,3-97\r\n8-96,7-7\r\n69-96,8-91\r\n87-88,8-88\r\n17-32,74-91\r\n13-93,13-93\r\n44-46,21-45\r\n37-49,49-50\r\n9-53,53-90\r\n43-51,49-49\r\n5-91,6-92\r\n12-77,12-13\r\n29-94,30-32\r\n77-78,53-77\r\n10-62,26-83\r\n44-46,45-60\r\n79-90,79-97\r\n5-89,89-89\r\n3-64,2-65\r\n58-96,73-96\r\n49-97,16-96\r\n27-49,26-50\r\n25-51,51-71\r\n45-48,46-51\r\n80-81,3-80\r\n26-30,25-25\r\n94-95,50-94\r\n65-95,63-94\r\n11-95,3-44\r\n11-97,10-10\r\n97-98,2-97\r\n46-50,53-66\r\n7-23,22-97\r\n55-85,55-85\r\n85-92,11-85\r\n98-99,5-99\r\n60-61,4-61\r\n30-31,8-30\r\n53-54,38-53\r\n2-3,4-5\r\n3-99,2-99\r\n19-85,21-66\r\n36-53,36-50\r\n70-71,24-70\r\n19-85,20-85\r\n1-84,15-86\r\n30-57,30-58\r\n78-81,77-82\r\n19-26,26-27\r\n52-73,51-72\r\n73-89,69-88\r\n2-5,4-79\r\n9-35,10-34\r\n4-60,3-61\r\n5-5,4-69\r\n98-99,16-98\r\n57-85,85-86\r\n1-81,2-80\r\n44-73,44-73\r\n90-97,68-90\r\n75-88,1-75\r\n95-98,12-95\r\n40-66,39-67\r\n3-99,4-26\r\n52-76,93-99\r\n16-30,30-66\r\n68-69,68-69\r\n19-68,9-19\r\n37-90,37-41\r\n1-94,94-94\r\n2-2,1-83\r\n12-93,2-12\r\n27-96,17-28\r\n44-46,36-67\r\n72-90,73-89\r\n20-29,21-21\r\n7-59,59-60\r\n69-74,66-74\r\n27-82,69-83\r\n12-78,12-78\r\n13-64,63-70\r\n41-60,40-40\r\n32-96,59-97\r\n1-98,1-97\r\n9-64,8-19\r\n4-4,3-97\r\n8-96,8-9\r\n5-5,4-68\r\n44-68,45-45\r\n42-67,41-71\r\n49-50,18-49\r\n1-95,83-91\r\n7-8,7-82\r\n31-76,32-75\r\n45-63,54-64\r\n92-93,84-92\r\n94-96,95-97\r\n21-61,20-62\r\n13-67,5-42\r\n15-58,16-84\r\n47-55,29-46\r\n56-65,55-57\r\n11-53,12-52\r\n1-48,48-57\r\n20-75,15-75\r\n1-95,21-95\r\n2-39,3-90\r\n4-54,24-55\r\n8-42,41-46\r\n9-97,9-98\r\n45-83,39-82\r\n23-72,22-71\r\n68-68,62-68\r\n2-96,1-1\r\n15-90,16-91\r\n25-27,26-93\r\n34-36,30-35\r\n2-65,3-64\r\n2-54,53-54\r\n39-84,38-84\r\n9-96,10-96\r\n79-80,70-76\r\n22-47,31-47\r\n13-87,12-87\r\n87-93,87-94\r\n24-44,25-94\r\n36-93,6-97\r\n8-94,28-41\r\n50-61,56-62\r\n32-74,74-75\r\n3-78,13-78\r\n99-99,23-87\r\n25-83,25-83\r\n15-15,14-20\r\n62-63,32-63\r\n36-49,35-57\r\n48-93,14-49\r\n52-71,51-53\r\n1-2,1-11\r\n22-99,98-99\r\n28-29,28-49\r\n7-8,7-81\r\n27-64,64-93\r\n13-59,14-60\r\n12-88,10-11\r\n13-79,14-50\r\n2-3,5-87\r\n18-77,18-76";
            List<String> inputPerLine = input.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList(); //String.Split() only takes 1 char as delimiter. This is how you split by a string according to StackOverflow.

            long totalOverlaps = 0;
            long partialOverlaps = 0;
            foreach(String line in inputPerLine)
            {
                String[] assignments = line.Split(',');
                String[] assignment1 = assignments[0].Split('-');
                String[] assignment2 = assignments[1].Split('-');

                bool assignment1StartsEarlierIncl = long.Parse(assignment1[0]) <= long.Parse(assignment2[0]);
                bool assignment2StartsEarlierIncl = long.Parse(assignment2[0]) <= long.Parse(assignment1[0]);
                bool assignment1EndsLaterIncl = long.Parse(assignment1[1]) >= long.Parse(assignment2[1]);
                bool assignment2EndsLaterIncl = long.Parse(assignment2[1]) >= long.Parse(assignment1[1]);
                if ((assignment1StartsEarlierIncl && assignment1EndsLaterIncl) || (assignment2StartsEarlierIncl && assignment2EndsLaterIncl))
                {
                    //Console.WriteLine("Got a total overlap! {0}", line);
                    totalOverlaps++;
                }
                else
                {
                    //Console.WriteLine("No total overlap for: {0}", line);
                }

                bool assignment1StartsEarlierExcl = long.Parse(assignment1[0]) < long.Parse(assignment2[0]);
                bool assignment1EndsEarlierExcl = long.Parse(assignment1[1]) < long.Parse(assignment2[0]);
                bool assignment1StartsLaterExcl = long.Parse(assignment1[0]) > long.Parse(assignment2[1]);
                bool assignment1EndsLaterExcl = long.Parse(assignment1[1]) > long.Parse(assignment2[1]);
                if ((assignment1StartsEarlierExcl && assignment1EndsEarlierExcl) || (assignment1StartsLaterExcl && assignment1EndsLaterExcl))
                {
                    Console.WriteLine("No partial overlap for: {0}", line);
                }
                else
                {
                    Console.WriteLine("Got a partial overlap! {0}", line);
                    partialOverlaps++;
                }
            }
            Console.WriteLine("Total overlaps: {0}/{1}", totalOverlaps, inputPerLine.Count);
            Console.WriteLine("Partial overlaps: {0}/{1}", partialOverlaps, inputPerLine.Count);
        }
    }
}
