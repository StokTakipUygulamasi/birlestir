   M S B A M L   `   `   `  ����N  JStokTakipUygulamasi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:StokTakipUygulamasi.PencerelerStokTakipUygulamasi.Pencereler  5   	   7    1StokTakipUygulamasi.Pencereler.hizliSatisUrunleri   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:StokTakipUygulamasi.Pencereler     5   	     � Title$  hizliSatisUrunleri��5   	   $��478.064��6$   $	��700��65    � AllowsTransparency .  � WindowStyle$
 None=�6[    � WindowStartupLocation$ CenterScreen=�6�   ��6n   Z� .��5	      �  � RowDefinitions 5
   
   �� 5       � ColumnDefinitions 5   
   �� 5      .+�5   
   �� .+�5      �� $��Ürün Ara:��6    K� ZIndex$ 10��6(   $
��Bold"�6:    �� Left$	 157��6L   
 �� Top$ 82��6^   $��67��6n   �� 5      -   5        	 ��Name$	 
txtUrunAra��5      $	��325��6*   $��30��66   $ 10��6B   $��16(�6T   $	 229��6b   $ 82��6t   6�   �� 5      $%��/images/icons/yetki_ayarlar.png��6   $ 65��6=   $��58��6N   $��54��6Z   $ 3                    ��6e   
 J� RenderTransformOrigin$
 0.141,0.379&�5      $ 31��6:   �� 5      $(��"HIZLI ÜRÜNLER AYARLAR PENCERESİ��6   $
��Bold"�6>   $��18(�6P   $	 173��6^   $ 31��6p   $ 3��6�   ���	#FFF6EDED$��35��6�   $��Center=�6�   $��Center=�6�      Label_yanip_sonme_efekti#���   6�   �� 5      $��35��6   $	��514��6$   $	 103��60   $ 31��6B   ���	#FF134187$ 1��6c   A� 5      $	��118��6   $	��115��6#   $ 37��6/   $ 2��6@   $��4��6Q   $
 0.5,0.5&�6e     donme_efekti#���  6�   z�5      �� 5      ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ 	#FF134187��6'    � Offset$ 0.997Q�69   � 5      $ 	#FFFCFCFC��6'   $
 0.89Q�69   � 5       $ 	#FFF0F2F6��6'   $ 0.913Q�69   � 5!      $ 	#FF90A5C6��6'   $ 0.957Q�69   5"      ��5$      �� 5%      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5&      � $ 	#FF134187��6'   $ 0Q�69   � 5'      $ White��6'   $ 0.713Q�65   � 5(      $ 	#FF4B6EA3��6'   $
 0.93Q�69   � 5)      $ White��6'   $
 0.35Q�65   5*      5,      �� 5.      $��0��6   $	��514��6"   $	��410��6.   $	 103��6;   $ 58��6M    �� CornerRadius$ 	0,0,50,50��6]   ���	#FFE0E0E0 J� Effect 5/      3  -System.Windows.Media.Effects.DropShadowEffect  50         Opacity$
 0.35Q�6'      	Direction$	 275Q�66   ._�53      &   System.Windows.Controls.DataGrid  -   5          Name$ dtg_HizliUrunlerListesi��53         SelectionMode$ Single=�6<   ���	#FF042263   
IsReadOnly .    	RowHeight$ 30Q�54   :      CanUserAddRows .     CanUserSortColumns .    CanUserReorderColumns .     CanUserResizeRows .     HorizontalGridLinesBrush �	#FF989B9B   VerticalGridLinesBrush �	#FFBBBBBB   HeadersVisibility$ Column=�56   Y      AutoGenerateColumns .    DataGridStyle#���  57   -   $��51,68,59.6,91.6q�6U   $
��Auto=�58      $
��Auto=�6M   ��53   S   Z� ��6i   Z� ��55   I   ��    Columns 5:      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn    
IsReadOnly  . !   Header$! ID��6W   "   MaxWidth$" 2Q�6c   1  +System.Windows.Controls.DataGridBoundColumn#   Binding# 6.   �� *ID+$   ElementStyle$ 5>      �� 5?   "   % �� 
TargetType"% ��6(   .�5@   &   �� & �� Property& � ��' �� Value$
' Left=�6L   �� 5A   &   & � ��$' Center=�6J   �� 5B   &   & �@��Padding$' 5q�6@   �� 5C   &   & � ��$	' 0.1(�6A   5D   #   (   	CellStyle( 5G      �� 5H   "   *  $System.Windows.Controls.DataGridCell"%  6(   .�5I   &   �� & � ��' �#2e61af6C   �� 5J   &   & � ��' �	#FF1341876D   �� 5K   &   & � ��$' 0,0,0,0q�6H   �� 5L   &   & � ��
' �����6C   5N   #   5P        5R        . $! Ürün Adı��6\   )   MinWidth$) 80Q�6n   *   Width5  /System.Windows.Controls.DataGridLengthConverter$	* 270 6|   + �� TextAlignment$+ Center=�6�   $��Expanded&�6�   # 6-   �� *
Urun_Adi+$ 5S      �� 5T   "   "% ��6(   .�5U   &   �� & � ��$
' Left=�6L   �� 5V   &   & � ��$' Center=�6J   �� 5W   &   & �@��Padding$' 5q�6@   5X   #   5Z      4  .System.Windows.Controls.DataGridTemplateColumn  5\      $! Seçim (Max 12)��61   ,   CellTemplate, 5]      �� 5^   "   .R�5_   &   �� $��checkbox_Secim��6u   -   5        - d� 	IsChecked- 5_   /   �� . �� Path$. Secim�/ �� UpdateSourceTrigger$/ PropertyChanged=�6�   5`   #   5b      5g      5h      d� 5i      -   5        0 d�Name$0 	btn_Bilgi��5i   x     DaireButonbilgi#���  6   $	 565��6E   $ 23��6W   $ 3��6g   6�   �� 5j      -   5        1 ��Name$1 btnKapat��5j   r     DaireButonCikis#���  6   $ 3��6?   $	 504��6P   $ 23��6b   ���	#FFEAEBF4$��2q�6�   � 5n      $	��318��6   $	��366��6    $	 478��6,   $ 17��6>   $ 20��6N   .+�5o      � -   5        2 �Name$2 popup_bilgi��5o   +   $��Center=�6   3 � AllowsTransparency3 . $��Scroll=�6Z   .��5p      �� 
����  �$	��179��63   $	��225��6@   $ 
0,20,30,30��6L   ._�5q      �� $��7q�6%   .+�5r      �� $��Bilgilendirme Metni��6(   
�������$
��Bold"�6V   $��22(�6h   $��Center=�6v   �� 5s      -   5        4 ��Name$4 txtBilgiPenceresi��5s   <   $
��Wrap=�6(   
�������$��0,10,0,0q�6j   5t      5u      5w      5x      �� 5z      $ 5��6   $	 103��6&   $	 500��68   $
��1087��6I   ]� 5{      $	 103��6   $	 350��6*   $	��511��6;   .+�5|      �� 5 �� Orientation$5 
Horizontal=�6   $
��Left=�66   $	��107��6Q   .+�5}      �� -   5        $1 btnHizliUrunleriGuncelle��5}   u     UrunEkleButonu#���  6   $	��449��6F   $"��Hızlı Ürünleri Güncelle��6R   $��30,29,0,24.2q�6�   5~      �� 5      $5 
Horizontal=�6   $��Right=�66   5�      5�      5�      5�      