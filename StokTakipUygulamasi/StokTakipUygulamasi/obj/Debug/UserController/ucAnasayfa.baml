   M S B A M L   `   `   `  ����N  JStokTakipUygulamasi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:StokTakipUygulamasi.UserController"StokTakipUygulamasi.UserController  5      3    -StokTakipUygulamasi.UserController.ucAnasayfa   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:StokTakipUygulamasi.UserController     5      -   5        .��5	      �   J� RenderTransformOrigin$  0.289,0.367&�6    � RowDefinitions 5
   
   �� 5      �� 5      $��50 �6   .+�5   
   �� .+�5      �� -   5        $��stackpanel_calisanlar��5   &   $	��347��6   $	��508��6C    K� ZIndex$ 10��6O    �� Left$ 30��6a   
 �� Top$ 43��6r   .+�5      �� $��ÇALIŞANLAR��6   
����  �$��Center=�6?   $
��Bold"�6\   $��214,0,210,0q�6n   $��26��6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$ dtg_calisanlar��5   y      AlternatingRowBackground
 �����   HorizontalGridLinesBrush
 �  ��   VerticalGridLinesBrush
 ��  �
���  �����	#FF042263	   
IsReadOnly	 . 
   	RowHeight$
 30Q�5   @      CanUserAddRows .     CanUserSortColumns .    CanUserReorderColumns .     CanUserResizeRows .     HeadersVisibility$ Column=�5         AutoGenerateColumns .  $	��206��5   3   $	��473��6@   $��
24,10,0,10q�6L   $	��Top=�6`   $
��Left=�6x   ��5   �   �� ��6�   Z�    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ ID��6V      MaxWidth$ 2Q�6b   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   �� *ID+   ElementStyle 5      �� 5   "    �� 
TargetType" ��6(   .�5   &   ��  �� Property � �� �� Value$
 Left=�6L   �� 5   &    � ��$ Center=�6J   �� 5   &    �@��Padding$ 5q�6@   �� 5    &    � ��$	 0.1(�6A   5"   #      	CellStyle 5%      �� 5&   "   *  $System.Windows.Controls.DataGridCell"  6(   .�5'   &   ��  � �� �#2e61af6C   �� 5(   &    � �� �	#FF1341876D   �� 5)   &    � ��$ 0,0,0,0q�6H   �� 5*   &    � ��
 �����6C   5,   #   5.        50       . $
 Adı��6W      MinWidth$	 110Q�6d    �� TextAlignment$ Center=�6s   $��Expanded&�6�    6-   �� *Ad+ 51      �� 52   "   " ��6(   .�53   &   ��  � ��$
 Left=�6L   �� 54   &    � ��$ Center=�6J   �� 55   &    �@��Padding$ 5,0,5,0q�6@   56   #   58        5:       . $ Soyadı��6Y   $	 135Q�6i   $ Center=�6x   $��Expanded&�6�    6-   �� *Soyad+ 5;      �� 5<   "   " ��6(   .�5=   &   ��  � ��$
 Left=�6L   �� 5>   &    � ��$ Center=�6J   �� 5?   &    �@��Padding$ 5,0,5,0q�6@   5@   #   5B        5D       . $ 	Departman��6Y   $	 135Q�6l      Width5  /System.Windows.Controls.DataGridLengthConverter$	 180 6{   $ Center=�6�   $��Expanded&�6�    6-   �� *Yetki+ 5E      �� 5F   "   " ��6(   .�5G   &   ��  � ��$
 Left=�6L   �� 5H   &    � ��$ Center=�6J   �� 5I   &    �@��Padding$ 5,0,5,0q�6@   5J   #   5L      5P      �� 5R       � Cursor$
 Hand��6   $��BİLGİLERİNİ GETİR��6&   $��Center=�6B   
����  �$ 5��6q   $
��Bold"�6�   5S      5T      �� 5\   
   $	��120��6   $��30��6   $	��Top=�6)   $��Right=�6A   ���	#FF213874$��	0,40,40,0q�6t    �� CornerRadius$ 10��6�   ._�5]      �� �� 5^      $��Dolar: ��6   $��50��6*   
�������$
��Bold"�6H    �� 5_      -   5          ��Name$  lblDolar��5_      $�� ��6+   $	 724��66   $ 19��6H   $��48��6X   
�������$��Right=�6v   5`      5b      �� 5e   
   
�������$��1��6$   ._�5f      �� ! �� Orientation$! 
Horizontal=�6   $��Right=�62   .+�5g      d� -   5        " d�Name$" 
btnCirolar��5g         ucAnasayfabutonlar#���   63   $��Cirolar��6`   $	��150��6r   $��40��6~   5h      5i      5n      5o      