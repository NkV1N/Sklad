   M S B A M L   `   `   `  ����D  @Warehouse, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Warehouse	Warehouse  5   	       Warehouse.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Warehouse     5   	     � Title$  	Warehouse��5   	   $	��450��6   $	��800��6(   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��200 �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��1* �6   .+�5   
   �� $��0��6   $��0��6    $��/Images/logo.png��6-   $��10q�6G   �� 5   
   $��1��6   $��10q�6"   .+�5      �� -   5        $��0, 10q�5      $��Bottom=�6$   
����h{�.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� Товары6(   5      5      �� 5      $��0, 10q�6   $��Bottom=�6$   
����h{�.��5      �� $ 
Horizontal=�6   .+�5      �� Остатки товаров61   5      5      �� 5       
����h{�$��0, 10q�5!      $��Bottom=�6   .��5"      �� $ 
Horizontal=�6   .+�5#      �� -   5         ��Name$ supllier��5#       Отгрузка6<   5$      5%      �� 5&      -   5         ��Name$ employee��5(      
����h{�$��0, 10q�5'      $��Bottom=�6   .��5)      �� $ 
Horizontal=�6   .+�5*      �� -   5        $ history��5*       !История отгрузок6C   5+      5,      �� 5-      -   5        
����h{�$��0, 10q�5/      $��Bottom=�6   .��50      �� $ 
Horizontal=�6   .+�51      �� 
Выход6(   52      53      54       � 55   
   -   5          �Name$ 	mainFrame��55      $��2��6#   $��1��64   56      57      