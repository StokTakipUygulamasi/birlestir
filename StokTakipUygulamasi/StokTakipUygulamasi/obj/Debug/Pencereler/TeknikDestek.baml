   M S B A M L   `   `   `  ����N  JStokTakipUygulamasi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:StokTakipUygulamasi.PencerelerStokTakipUygulamasi.Pencereler  5   	   1    +StokTakipUygulamasi.Pencereler.TeknikDestek   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:StokTakipUygulamasi.Pencereler     5   	     � Title$  TeknikDestek��5   	   $	��450��6   $	��800��6+    � AllowsTransparency .  � WindowStyle$
 None=�6g    � WindowStartupLocation$ CenterScreen=�6z   ��67   Z� .��5	      � .+�5
   
   �� .+�5      �� $)��#/images/icons/teknikDestek_mavi.png��6    �� Left$ 90��6A   $��58��6R   
 �� Top$ 41��6^   $��54��6n    K� ZIndex$ 3                    ��6y   �� 5      $��TEKNİK DESTEK PENCERESİ��6   $
��Bold"�66   $��18(�6H   $	 173��6V   $ 23��6h   $ 3��6x   ���	#FFF6EDED$��35��6�   $��Center=�6�   $��Center=�6�      Label_yanip_sonme_efekti#���   6�   �� 5      $��35��6   $	��502��6$   $	 103��60   $ 23��6B   ���	#FF134187$ 1��6c   A� 5      $	��118��6   $	��115��6#   $ 58��6/   $ 10��6@   $ 2��6P   $��4��6a    J� RenderTransformOrigin$ 0.5,0.5&�6u     donme_efekti#���  6�   z�5      �� 5      ��5      �� 5       �� EndPoint$ 0.5,1&�6*   	 �� 
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
 0.35Q�65   5"      5$      �� 5&      $	��502��6   $	��417��6!   $	 103��6.   $ 23��6@    �� CornerRadius$ 	0,0,50,50��6P   ���	#FFE0E0E0 J� Effect 5'      3  -System.Windows.Media.Effects.DropShadowEffect  5(         Opacity$
 0.35Q�6'      	Direction$	 275Q�66   5*      �� 5-      $��Gönderen: ��6   $	 237��6)   $ 75��6;   $
��Bold"�6K   �� 5.      -   5         ��Name$ txtGonderenCalisan��5.   Q   $	��212��6   $��24��6#   $	 329��6/   $ 75��6A   {�.  6m   �� 50      $��Mesajın Konusu: *��6   $	 204��60   $	 106��6B   $
��Bold"�6S   �� 51      -   5        $ txtMesajKonusu��51   a    �� 	MaxLength$	 255��6   $	��212��6&   $	 329��62   $	 106��6D   $��25��6U   $��18(�6y      MouseOverImageChange_Textbox#���  6�   �� 53      $��Cep Telefonu: ��6   $	 218��6-   $	 141��6?   $
��Bold"�6P   �� 54      -   5        $ 	txtCepTel��54   a   $ 10��6   $	��212��6&   $��26��62   $	 329��6>   $	 136��6P   $��18(�6t   #���  6�   6�   �� 56      $��Mesaj: *��6   $	 260��6'   $	 166��69   $
��Bold"�6J   �� 57      -   5        $ txtMesaj��57   v   $	 255��6    �� TextWrapping$
 Wrap=�6&   $	��212��6:   $	��132��6F   $	 329��6S   $	 166��6e   $��18(�6�   #���  6�   �� 59      $��Dosya: ��6   $	 263��6&   $	 310��68   $
��Bold"�6I   �� 5:      -   5         ��Name$ btnDosyaEkle��5:   J   $ 3��6   $	 329��6&   $	 305��68   $��Dosya seçilmedi��6`   $	��212��6�   $��31��6�   ]� 5;      -   5         ]�Name$ DockPanelDosyaAlani��5;   G   $	 329��6   $	 336��6*   $��52��6;   .+�5<      �� -   5         ��Name$ img_YuklenenDosya��5<   �    � Cursor$
 Hand��6   $ 5��6&   $��32��67   $��46��6B   $	 329��6N   $	 340��6`   $��/images/icons/dosyaAc.png��6q   6�   �� 5=      -   5         ��Name$ lblDosyaAdi��5=      ���	#FF00FF1F$	 361��6D   $	 341��6V   $	��107��6g   $
 Hand��6s   $
��0,10q�6�   5>      �� 5?      -	   5        $ btn_MesajiGonder��5?   �     UrunEkleButonu#���  6   $	��212��6>   $��39��6J   $��Mesajı Gönder��6V   $	 329��6o   $��0q�6�   $	 391��6�   6�   d� 5@      -
   5         d�Name$ 	btn_Bilgi��5@   x     DaireButonbilgi#���  6   $	 559��6E   $ 17��6W   $ 3��6g   6�   �� 5A      -   5        $ btnKapat��5A   r     DaireButonCikis#���  6   $ 3��6?   $	 504��6P   $ 17��6b   ���	#FFEAEBF4$��2q�6�   � 5E      $	��318��6   $	��366��6    $	 484��6,   $ 17��6>   .+�5F      � -   5         �Name$ popup_bilgi��5F   +   $��Center=�6    � AllowsTransparency . $��Scroll=�6Z   .��5G      �� 
����  �$	��179��63   $	��225��6@   $ 
0,20,30,30��6L   ._�5H      �� $��7q�6%   .+�5I      �� $��Bilgilendirme Metni��6(   
�������$
��Bold"�6V   $��22(�6h   $��Center=�6v   �� 5J      -   5         ��Name$ txtBilgiPenceresi��5J   (   $
��Wrap=�6C   
�������$��0,10,0,0q�6j   5K      5L      5N      5Q      5T      5U      5V      