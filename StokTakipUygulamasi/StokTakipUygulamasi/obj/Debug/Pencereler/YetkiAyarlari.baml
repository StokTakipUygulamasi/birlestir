   M S B A M L   `   `   `  ����N  JStokTakipUygulamasi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:StokTakipUygulamasi.PencerelerStokTakipUygulamasi.Pencereler  5   	   2    ,StokTakipUygulamasi.Pencereler.YetkiAyarlari   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:StokTakipUygulamasi.Pencereler     5   	     � Title$  YetkiAyarlari��5   	   $	��500��6   $
��1000��6,    � AllowsTransparency .  � WindowStyle$
 None=�6i    � WindowStartupLocation$ CenterScreen=�6|   ��69   Z� .��5	      �  � RowDefinitions 5
   
   �� 5       � ColumnDefinitions 5   
   �� 5      .+�5   
   �� .+�5      �� $%��/images/icons/yetki_ayarlar.png��6    �� Left$ 65��6=   $��58��6N   $��54��6Z    K� ZIndex$ 3                    ��6e    J� RenderTransformOrigin$ 0.141,0.379&�5      
	 �� Top$	 31��6:   �� 5      $2��,YETKİLER VE DEPARTMANLAR AYARLAR PENCERESİ��6   $
��Bold"�6I   $��18(�6[   $	 173��6i   $	 31��6{   $ 3��6�   ���	#FFF6EDED$��35��6�   $��Center=�6�   $��Center=�6�      Label_yanip_sonme_efekti#���   6�   �� 5      $��35��6   $	��806��6$   $	 103��60   $	 31��6B   ���	#FF134187$ 1��6c   A� 5      $	��118��6   $	��115��6#   $ 37��6/   $ 2��6@   $��4��6Q   $ 0.5,0.5&�6e     donme_efekti#���  6�   z�5      �� 5      ��5      �� 5      
 �� EndPoint$
 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ 	#FF134187��6'    � Offset$ 0.997Q�69   � 5      $ 	#FFFCFCFC��6'   $
 0.89Q�69   � 5      $ 	#FFF0F2F6��6'   $ 0.913Q�69   � 5       $ 	#FF90A5C6��6'   $ 0.957Q�69   5!      ��5#      �� 5$      $
 0.5,1&�6*   $ 0.5,0&�6;   .��5%      � $ 	#FF134187��6'   $ 0Q�69   � 5&      $ White��6'   $ 0.713Q�65   � 5'      $ 	#FF4B6EA3��6'   $
 0.93Q�69   � 5(      $ White��6'   $
 0.35Q�65   5)      5+      �� 5-      $��0��6   $	��806��6"   $	��363��6.   $	 103��6;   $	 58��6M    �� CornerRadius$ 	0,0,50,50��6]   ���	#FFE0E0E0 J� Effect 5.      3  -System.Windows.Media.Effects.DropShadowEffect  5/         Opacity$
 0.35Q�6'      	Direction$	 275Q�66   ._�51      &   System.Windows.Controls.DataGrid  -   5          Name$ dtg_YetkiListesi��51         SelectionMode$ Single=�65   ���	#FF042263   
IsReadOnly .    	RowHeight$ 30Q�52   :      CanUserAddRows .     CanUserSortColumns .    CanUserReorderColumns .     CanUserResizeRows .     HorizontalGridLinesBrush �	#FF989B9B   VerticalGridLinesBrush �	#FFBBBBBB   HeadersVisibility$ Column=�54   Y      AutoGenerateColumns .    DataGridStyle#���  55   -   $��132,34,159.4,94.2q�6U   $
��Auto=�56      $
��Auto=�6M   ��51   L   Z� ��6b   Z� ��53   I   ��    Columns 58      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .     Header$  ID��6W   !   MaxWidth$! 2Q�6c   1  +System.Windows.Controls.DataGridBoundColumn"   Binding" 6.   �� *ID+#   ElementStyle# 5<      �� 5=   "   $ �� 
TargetType"$ ��6(   .�5>   &   �� % �� Property% � ��& �� Value$
& Left=�6L   �� 5?   &   % � ��$& Center=�6J   �� 5@   &   % �@��Padding$& 5q�6@   �� 5A   &   % � ��$	& 0.1(�6A   5B   #   '   	CellStyle' 5E      �� 5F   "   *  $System.Windows.Controls.DataGridCell"$  6(   .�5G   &   �� % � ��& �#2e61af6C   �� 5H   &   % � ��& �	#FF1341876D   �� 5I   &   % � ��$& 0,0,0,0q�6H   �� 5J   &   % � ��
& �����6C   5L   #   5N        5P       . $  Departman Kodu��6^   (   MinWidth$( 80Q�6v   )   Width5  /System.Windows.Controls.DataGridLengthConverter$	) 200 6�   * �� TextAlignment$* Center=�6�   $��Expanded&�6�   " 6-   �� *
Yetki_Kodu+# 5Q      �� 5R   "   "$ ��6(   .�5S   &   �� % � ��$
& Left=�6L   �� 5T   &   % � ��$& Center=�6J   �� 5U   &   % �@��Padding$& 5q�6@   5V   #   5X        5Z       . $  	Departman��6Y   $( 80Q�6l   $	) 300 6z   $* Center=�6�   $��Expanded&�6�   " 6-   �� *Yetki+# 5[      �� 5\   "   "$ ��6(   .�5]   &   �� % � ��$
& Left=�6L   �� 5^   &   % � ��$& Center=�6J   �� 5_   &   % �@��Padding$& 5q�6@   5`   #   5b      5f      5g      d� 5h      -   5        + d�Name$+ 	btn_Bilgi��5h   x     DaireButonbilgi#���  6   $	 851��6E   $	 21��6W   $ 3��6g   6�   �� 5i      -   5        , ��Name$, btnKapat��5i   r     DaireButonCikis#���  6   $ 3��6?   $	 790��6P   $	 21��6b   ���	#FFEAEBF4$��2q�6�   � 5m      $	��318��6   $	��366��6    $	 764��6,   $	 14��6>   $ 20��6N   .+�5n      � -   5        - �Name$- popup_bilgi��5n   +   $��Center=�6   . � AllowsTransparency. . $��Scroll=�6Z   .��5o      �� 
����  �$	��179��63   $	��225��6@   $ 
0,20,30,30��6L   ._�5p      �� $��7q�6%   .+�5q      �� $��Bilgilendirme Metni��6(   
�������$
��Bold"�6V   $��22(�6h   $��Center=�6v   �� 5r      -   5        / ��Name$/ txtBilgiPenceresi��5r   <   $
��Wrap=�6(   
�������$��0,10,0,0q�6j   5s      5t      5v      5w      �� 5y      $ 5��6   $	 103��6&   $		 490��68   $
��1087��6I   ]� 5z      $	 103��6   $		 322��6*   $	��806��6;   .+�5{      �� 0 �� Orientation$0 
Horizontal=�6   $
��Left=�66   .+�5|      �� -   5        $, btnIsmiGuncelle��5|   }     UrunEkleButonu#���  6   $	��158��6F   $��50��6R   $��Departmanı güncelle��6^   $��
30,25,0,25q�6�   �� 5}      -   5        $, btnSil��5}   l   #���  6   $��52��6F   $��50��6Q   $	��Sil��6]   $��
10,25,0,25q�6}   6�   �� 5~      -   5        1 ��Name$1 checkbox_silinenYetkiler��5~   �   $��Silinen Departmanlar��6   $��30��6>   $��5q�6J   $��16(�6^   $��Center=�6l   $��20,0,0,0q�6�   $	��178��6  �� 5      -	   5        $, 	btnGeriAl��5   p   #���  6   $��70��6F   $��50��6Q   $��Geri Al��6]   $��
10,25,0,25q�6�   6�   5�      �� 5�      $0 
Horizontal=�6   $��Right=�66   .+�5�      �� -
   5        $, btnDepartmanEkle��5�   x   #���  6   $	��107��6F   $��50��6R   $��Departman Ekle��6^   $��
0,25,25,25q�6�   6�   5�      5�      5�      5�      5�      