   M S B A M L   `   `   `  ����N  JStokTakipUygulamasi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:StokTakipUygulamasi.PencerelerStokTakipUygulamasi.Pencereler  5   	   ;    5StokTakipUygulamasi.Pencereler.OlcuBirimleriEkleCikar   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:StokTakipUygulamasi.Pencereler     5   	     � Title$  OlcuBirimleriEkleCikar��5   	   $	��450��6(   $	��800��65    � AllowsTransparency .  � WindowStyle$
 None=�6q    � WindowStartupLocation$ CenterScreen=�6�   ��6A   Z� .��5	      �  � RowDefinitions 5
   
   �� 5       � ColumnDefinitions 5   
   �� 5      .+�5   
   �� .+�5      �� $%��/images/icons/yetki_ayarlar.png��6    �� Left$ 65��6=   $��58��6N   $��54��6Z    K� ZIndex$ 3                    ��6e    J� RenderTransformOrigin$ 0.141,0.379&�5      
	 �� Top$	 31��6:   �� 5      $-��'ÖLÇÜ BİRİMLERİ AYARLAR PENCERESİ��6   $
��Bold"�6?   $��18(�6Q   $	 173��6_   $	 31��6q   $ 3��6�   ���	#FFF6EDED$��35��6�   $��Center=�6�   $��Center=�6�      Label_yanip_sonme_efekti#���   6�   �� 5      $��35��6   $	��603��6$   $	 103��60   $	 31��6B   ���	#FF134187$ 1��6c   A� 5      $	��118��6   $	��115��6#   $ 37��6/   $ 2��6@   $��4��6Q   $ 0.5,0.5&�6e     donme_efekti#���  6�   z�5      �� 5      ��5      �� 5      
 �� EndPoint$
 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ 	#FF134187��6'    � Offset$ 0.997Q�69   � 5      $ 	#FFFCFCFC��6'   $
 0.89Q�69   � 5      $ 	#FFF0F2F6��6'   $ 0.913Q�69   � 5       $ 	#FF90A5C6��6'   $ 0.957Q�69   5!      ��5#      �� 5$      $
 0.5,1&�6*   $ 0.5,0&�6;   .��5%      � $ 	#FF134187��6'   $ 0Q�69   � 5&      $ White��6'   $ 0.713Q�65   � 5'      $ 	#FF4B6EA3��6'   $
 0.93Q�69   � 5(      $ White��6'   $
 0.35Q�65   5)      5+      �� 5,      $��Ölçü Birimi Ara��6   $ 5��6.   $	 213��6?   $	 92��6Q   $��26��6a   �� 5-      -   5         ��Name$ txtOlcuBirimiAra��5-   q    �� 	MaxLength$	 255��6   $	��276��6&   $��26��62   $	 308��6>   $	 92��6P   $ 5��6`   $��18(�6�   �� 5.      $��0��6   $	��603��6"   $	��363��6.   $	 103��6;   $	 58��6M    �� CornerRadius$ 	0,0,50,50��6]   ���	#FFE0E0E0 J� Effect 5/      3  -System.Windows.Media.Effects.DropShadowEffect  50         Opacity$
 0.35Q�6'      	Direction$	 275Q�66   ._�52      &   System.Windows.Controls.DataGrid  -   5          Name$ dtg_OlcuBirimiListesi��52         SelectionMode$ Single=�6:   ���	#FF042263   
IsReadOnly .    	RowHeight$ 30Q�53   :      CanUserAddRows .     CanUserSortColumns .    CanUserReorderColumns .     CanUserResizeRows .     HorizontalGridLinesBrush �	#FF989B9B   VerticalGridLinesBrush �	#FFBBBBBB   HeadersVisibility$ Column=�55   Y      AutoGenerateColumns .    DataGridStyle#���  56   -   $��108,72,121.2,93.2q�6U   $
��Auto=�57      $
��Auto=�6M   ��52   Q   Z� ��6g   Z� ��54   I   ��     Columns  59      0  *System.Windows.Controls.DataGridTextColumn  5<      ,  &System.Windows.Controls.DataGridColumn!   
IsReadOnly! . "   Header$" ID��6W   #   MaxWidth$# 2Q�6c   1  +System.Windows.Controls.DataGridBoundColumn$   Binding$ 6.   �� *ID+%   ElementStyle% 5=      �� 5>   "   & �� 
TargetType"& ��6(   .�5?   &   �� ' �� Property' � ��( �� Value$
( Left=�6L   �� 5@   &   ' � ��$( Center=�6J   �� 5A   &   ' �@��Padding$( 5q�6@   �� 5B   &   ' � ��$	( 0.1(�6A   5C   #   )   	CellStyle) 5F      �� 5G   "   *  $System.Windows.Controls.DataGridCell"&  6(   .�5H   &   �� ' � ��( �#2e61af6C   �� 5I   &   ' � ��( �	#FF1341876D   �� 5J   &   ' � ��$( 0,0,0,0q�6H   �� 5K   &   ' � ��
( �����6C   5M   #   5O        5Q      ! . $" Ölçü Birimi Adı��6_   *   MinWidth$* 80Q�6x   +   Width5  /System.Windows.Controls.DataGridLengthConverter$	+ 350 6�   , �� TextAlignment$, Center=�6�   $��Expanded&�6�   $ 6-   �� *Olcu_Birimi+% 5R      �� 5S   "   "& ��6(   .�5T   &   �� ' � ��$
( Left=�6L   �� 5U   &   ' � ��$( Center=�6J   �� 5V   &   ' �@��Padding$( 5q�6@   5W   #   5Y      5]      5^      d� 5_      -   5        - d�Name$- 	btn_Bilgi��5_   x     DaireButonbilgi#���  6   $	 651��6E   $	 17��6W   $ 3��6g   6�   �� 5`      -   5        . ��Name$. btnKapat��5`   r     DaireButonCikis#���  6   $ 3��6?   $	 590��6P   $	 17��6b   ���	#FFEAEBF4$��2q�6�   � 5d      $	��318��6   $	��366��6    $	 564��6,   $	 10��6>   $ 20��6N   .+�5e      � -   5        / �Name$/ popup_bilgi��5e   +   $��Center=�6   0 � AllowsTransparency0 . $��Scroll=�6Z   .��5f      �� 
����  �$	��179��63   $	��225��6@   $ 
0,20,30,30��6L   ._�5g      �� $��7q�6%   .+�5h      �� $��Bilgilendirme Metni��6(   
�������$
��Bold"�6V   $��22(�6h   $��Center=�6v   �� 5i      -   5        1 ��Name$1 txtBilgiPenceresi��5i   <   $
��Wrap=�6(   
�������$��0,10,0,0q�6j   5j      5k      5m      5n      �� 5p      $ 5��6   $	 103��6&   $		 490��68   $
��1087��6I   ]� 5q      $	 103��6   $		 322��6*   $	��590��6;   .+�5r      �� 2 �� Orientation$2 
Horizontal=�6   $
��Left=�66   .+�5s      �� -   5        $. btnGuncelle��5s   �     UrunEkleButonu#���  6   $��66��6F   $��50��6Q   $��	Güncelle��6]   $��
30,25,0,25q�6�   �� 5t      -   5        $. btnSil��5t   l   #���  6   $��52��6F   $��50��6Q   $	��Sil��6]   $��
10,25,0,25q�6�   �� 5u      -	   5        3 ��Name$#3 checkbox_silinenOlcuBirimleri��5u   �   $��Silinen Ölçü Birimleri��6   $��30��6@   $��5q�6L   $��16(�6`   $��Center=�6n   $��20,0,0,0q�6�   $	��182��6&  �� 5v      -
   5        $. 	btnGeriAl��5v   p   #���  6   $��61��6F   $��50��6Q   $��Geri Al��6]   $��
10,25,0,25q�6�   6�   5w      �� 5x      $2 
Horizontal=�6   $��Right=�66   .+�5y      �� -   5        $. btnOlcuBirimiEkle��5y   z   #���  6   $	��107��6F   $��50��6R   $��Ölçü Birimi Ekle��6^   $��
0,25,25,25q�6�   5z      5{      5}      5�      5�      