   M S B A M L   `   `   `  ����D  @Warehouse, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Warehouse.ViewsWarehouse.Views  5      !    Warehouse.Views.ProductPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Warehouse.Views     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  ProductPage��5       � DataContext 5      ��  �� Mode$ OneWay=� �� RelativeSource �� *Self+.��5      ]� .+�5   
   �� $	��Top=�6   $��35(�6%   $
��Bold"�63   
�����_�$��Товары��5      $��0 0 0 25q�6   �� 5   
    �� Orientation$ 
Horizontal=�6   $	��Top=�5   	   .+�5      �� $5��/Поиск товара по названию: ��6   $��18(�69   $��Center=�6G      MaterialDesignLabel#���   5      �� 5      -   5         ��Name$ 
searchText��5   "   $	��200��6     MaterialDesignTextBox#���  5   
   $��18(�6:   �� 5      $;��5Выбрать по категории товара: ��6   $��18(�6<   $��10 0 0 0q�6J   $��Center=�5   	   #���   6$   �� 5      -   5         ��Name$ filterComboBox��5   #   $	��250��6     MaterialDesignComboBox#���  5      $��18(�6D   ��5   U   �� *CategoryFilters+��5      �� 5      .R�5      �� ��6    �� *Key+5      5      �� 5       -   5        $��	150 0 0 0q�5        $  MaterialDesignFlatAccentBgButton#���  6F   
������ .��5!      �� $ 
Horizontal=�6   .+�5"      '  !MaterialDesignThemes.Wpf.PackIcon  $��25��6.   $��25��6:      Kind$ DatabaseAdd=�6E   $	��5 0q�6X   �� 5#        MaterialDesignTextBlock#���  6    Добавить товар6b   5$      5%      5&      �� 5'   
   $��Bottom=�6     SecondaryHueMidBrush#���  6,   .@�5(      �� Показано �� 5)      �6   �� *CurrentCount+ из �� 6A   �6E   �� *
TotalCount+ записей5*      5+      �� 5,   
   -   5         ��Name$ searchResultLabel��5,      $��18(�6+   $��10q�69   $	��Top=�6E   $y�	Collapsed=�6Z   $;��5По запросу нечего не найдено!��6q   �� 5-   
   -   5        	 ��Name$	 listProduct��5-   4   $��Disabled=�5.      ��5-      �� *
Products+��5/      �� 50      .R�51      � 52      ��54      �� 55      .R�56      �� $��5q�6   $��1q�6(   
�����F�
 �� CornerRadius$
 4��6T   ._�57      � $
��1200��6    � ColumnDefinitions 58      �� 59   "   �� 5:   "   $	��150 �63   .+�5<      �� $��7q�6)   $��0��64   .+�5=   "   �� $��22(�6,   $
��Wrap=�6:   �� 5>   "   $��SemiBold"�6&   $��Italic$�6<   �6P   �� *Name+%# Категория товара - �� 5@   "   $��Italic$�6&   �69   �� *ProductType.Name+.5A   #   5B      �� 5C      $��1��6)   $��3q�69   $ 
Horizontal=�6D   $��Center=�6^   .+�5D   "   �� -   5        $��0 0 0 2q�5D   )     MaterialDesignFlatButton#���  6N   .��5E   &     $
 Edit=�6>   5F   #   �� 5G   "   -   5        $��0 0 0 2q�5G   )   #���  6:   .��5H   &     $ Remove=�6>   5I   #   5J      5K      5L      5M      5O      5P      5Q      