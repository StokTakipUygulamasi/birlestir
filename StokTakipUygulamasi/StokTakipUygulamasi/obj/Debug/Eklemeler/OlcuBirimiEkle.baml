   M S B A M L   `   `   `  ����N  JStokTakipUygulamasi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:StokTakipUygulamasi.EklemelerStokTakipUygulamasi.Eklemeler  5   	   2    ,StokTakipUygulamasi.Eklemeler.OlcuBirimiEkle   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:StokTakipUygulamasi.Eklemeler     5   	     � Title$  OlcuBirimiEkle��5   	   $	��450��6    $	��800��6-    � AllowsTransparency .  � WindowStyle$
 None=�6i    � WindowStartupLocation$ CenterScreen=�6|   ��69   Z� .��5	      � .+�5
   
   �� .+�5      �� $��/images/icons/ekle.png��6    �� Left$ 90��64   $��58��6E   
 �� Top$ 41��6Q   $��54��6a    K� ZIndex$ 3                    ��6l   �� 5      $)��#ÖLÇÜ BİRİMİ EKLEME PENCERESİ��6   $
��Bold"�6;   $��18(�6M   $	 173��6[   $ 23��6m   $ 3��6}   ���	#FFF6EDED$��35��6�   $��Center=�6�   $��Center=�6�      Label_yanip_sonme_efekti#���   6�   �� 5      $��35��6   $	��502��6$   $	 103��60   $ 23��6B   ���	#FF134187$ 1��6c   A� 5      $	��118��6   $	��115��6#   $ 58��6/   $ 10��6@   $ 2��6P   $��4��6a    J� RenderTransformOrigin$ 0.5,0.5&�6u     donme_efekti#���  6�   z�5      �� 5      ��5      �� 5       �� EndPoint$ 0.5,1&�6*   	 �� 
StartPoint$	 0.5,0&�6;   .��5      � 
 � Color$
 	#FF134187��6'    � Offset$ 0.997Q�69   � 5      $
 	#FFFCFCFC��6'   $
 0.89Q�69   � 5      $
 	#FFF0F2F6��6'   $ 0.913Q�69   � 5      $
 	#FF90A5C6��6'   $ 0.957Q�69   5      ��5      �� 5      $ 0.5,1&�6*   $	 0.5,0&�6;   .��5      � $
 	#FF134187��6'   $ 0Q�69   � 5      $
 White��6'   $ 0.713Q�65   � 5       $
 	#FF4B6EA3��6'   $
 0.93Q�69   � 5!      $
 White��6'   $
 0.35Q�65   5"      5$      �� 5&      $	��502��6   $	��387��6!   $	 103��6.   $ 23��6@    �� CornerRadius$ 	0,0,50,50��6P   ���	#FFE0E0E0 J� Effect 5'      3  -System.Windows.Media.Effects.DropShadowEffect  5(         Opacity$
 0.35Q�6'      	Direction$	 275Q�66   ._�5*      &   System.Windows.Controls.DataGrid  -   5          Name$ dtg_OlcuBirimiListesi��5*         SelectionMode$ Single=�6:   ���	#FF042263   
IsReadOnly .    	RowHeight$ 30Q�5+   :      CanUserAddRows .     CanUserSortColumns .    CanUserReorderColumns .     CanUserResizeRows .     HorizontalGridLinesBrush �	#FF989B9B   VerticalGridLinesBrush �	#FFBBBBBB   HeadersVisibility$ Column=�5-   Y      AutoGenerateColumns .    DataGridStyle#���  5.   -   $��96,107,100.4,88.2q�6U   $
��Auto=�5/      $
��Auto=�6M   ��5*   Q   Z� ��6g   Z� ��5,   I   ��    Columns 51      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ ID��6W      MaxWidth$ 2Q�6c   1  +System.Windows.Controls.DataGridBoundColumn    Binding  6.   �� *ID+!   ElementStyle! 55      �� 56   "   " �� 
TargetType"" ��6(   .�57   &   �� # �� Property# � ��$ �� Value$
$ Left=�6L   �� 58   &   # � ��$$ Center=�6J   �� 59   &   # �@��Padding$$ 5q�6@   �� 5:   &   # � ��$	$ 0.1(�6A   5;   #   %   	CellStyle% 5>      �� 5?   "   *  $System.Windows.Controls.DataGridCell""  6(   .�5@   &   �� # � ��$ �#2e61af6C   �� 5A   &   # � ��$ �	#FF1341876D   �� 5B   &   # � ��$$ 0,0,0,0q�6H   �� 5C   &   # � ��
$ �����6C   5E   #   5G        5I       . $ Ölçü Birimi Adı��6_   &   MinWidth$& 80Q�6x   '   Width5  /System.Windows.Controls.DataGridLengthConverter$	' 275 6�   ( �� TextAlignment$( Center=�6�   $��Expanded&�6�     6-   �� *Olcu_Birimi+! 5J      �� 5K   "   "" ��6(   .�5L   &   �� # � ��$
$ Left=�6L   �� 5M   &   # � ��$$ Center=�6J   �� 5N   &   # �@��Padding$$ 5q�6@   5O   #   5Q      5U      5V      �� 5Y      $��Ölçü Birimi Adı: *��6   $	 204��61   $ 94��6C   $
��Bold"�6S   �� 5Z      -   5        ) ��Name$) txtOlcuBirimiAdi��5Z   `   * �� 	MaxLength$	* 255��6   $	��187��6&   $��24��62   $	 316��6>   $ 94��6P   $��18(�6z      MouseOverImageChange_Textbox#���  6�   6�   �� 5`      -   5        + ��Name$+ btn_OlcuBirimiEkle��5`   �     UrunEkleButonu#���  6   $	��414��6>   $��39��6J   $��Ölçü Birimini Ekle��6V   $	 140��6t   $��0q�6�   $	 358��6�   6�   d� 5a      -   5        , d�Name$, 	btn_Bilgi��5a   x     DaireButonbilgi#���  6   $	 559��6E   $ 17��6W   $ 3��6g   6�   �� 5b      -   5        $+ btnKapat��5b   r     DaireButonCikis#���  6   $ 3��6?   $	 504��6P   $ 17��6b   ���	#FFEAEBF4$��2q�6�   �� 5d      $��0��6   $��5,3,3,0q�6"   � 5g      $	��318��6   $	��366��6    $	 484��6,   $ 17��6>   .+�5h      � -   5        - �Name$- popup_bilgi��5h   +   $��Center=�6   . � AllowsTransparency. . $��Scroll=�6Z   .��5i      �� 
����  �$	��179��63   $	��225��6@   $ 
0,20,30,30��6L   ._�5j      �� $��7q�6%   .+�5k      �� $��Bilgilendirme Metni��6(   
�������$
��Bold"�6V   $��22(�6h   $��Center=�6v   �� 5l      -   5        / ��Name$/ txtBilgiPenceresi��5l   (   $
��Wrap=�6C   
�������$��0,10,0,0q�6j   5m      5n      5p      5s      5v      5w      5x      