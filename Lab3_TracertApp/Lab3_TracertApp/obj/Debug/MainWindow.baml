   M S B A M L   `   `   `  ����J  FLab3_TracertApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Lab3_TracertAppLab3_TracertApp  5   	        Lab3_TracertApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Lab3_TracertApp     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.0.1244, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   $��15(�5   	   $��Medium"�5	   	     � Title$  
MainWindow��5   	   $	��450��6   $	��450��6)   .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� $��1��6   $��1��6!   $��	Address: ��61   �� 5   
   -   5        $��Address��5   1   $��1��6   $��2��6    61   �� 5!   
   $��2��6   $��1��6!   $��	Max TTL: ��61   �� 5"   
   -   5        $��MaxTtl��5"   1   $��2��6   $��2��6    61   �� 5$   
   $��3��6   $��1��6!   $��	Timeout: ��61   �� 5%   
   -   5        $��Timeout��5%   1   $��3��6   $��2��6    61   �� 5'   
   -   5        $��RequestButton��5(   #   $��4��5'      $��1��6   $��2��6.   $��15q�6B   $��Request��5(      
�������5)      �� 5*   
   -   5        $��listbox��5*   C   $��5��6   $��1��6   $��2��6/   
���z���6R   5+      5.      