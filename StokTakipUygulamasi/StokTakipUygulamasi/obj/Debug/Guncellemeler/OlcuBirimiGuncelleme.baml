   M S B A M L   `   `   `  ����N  JStokTakipUygulamasi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:StokTakipUygulamasi.Guncellemeler!StokTakipUygulamasi.Guncellemeler  5   	   <    6StokTakipUygulamasi.Guncellemeler.OlcuBirimiGuncelleme   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:StokTakipUygulamasi.Guncellemeler     5   	     � Title$  OlcuBirimiGuncelleme��5   	   $	��450��6&   $	��800��63    � AllowsTransparency .  � WindowStyle$
 None=�6o    � WindowStartupLocation$ CenterOwner=�6�   ��6?   Z� .��5	      � .+�5
   
   �� .+�5      �� $ ��/images/icons/guncelle.png��6    �� Left$ 90��68   $��58��6I   
 �� Top$ 41��6U   $��54��6e    K� ZIndex$ 3                    ��6p   �� 5      $.��(ÖLÇÜ BİRİMİ GÜNCELLEME PENCERESİ��6   $
��Bold"�6?   $��18(�6Q   $	 173��6_   $ 23��6q   $ 3��6�   ���	#FFF6EDED$��35��6�   $��Center=�6�   $��Center=�6�      Label_yanip_sonme_efekti#���   6�   �� 5      $��35��6   $	��502��6$   $	 103��60   $ 23��6B   ���	#FF134187$ 1��6c   A� 5      $	��118��6   $	��115��6#   $ 58��6/   $ 10��6@   $ 2��6P   $��4��6a    J� RenderTransformOrigin$ 0.5,0.5&�6u     donme_efekti#���  6�   z�5      �� 5      ��5      �� 5       �� EndPoint$ 0.5,1&�6*   	 �� 
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
 0.35Q�65   5"      5$      �� 5(      $	��502��6   $	��242��6!   $	 103��6.   $ 23��6@    �� CornerRadius$ 	0,0,50,50��6P   ���	#FFE0E0E0 J� Effect 5)      3  -System.Windows.Media.Effects.DropShadowEffect  5*         Opacity$
 0.35Q�6'      	Direction$	 275Q�66   5-      �� 52      $��Ölçü Birimi Eski Adı:��6   $	 172��64   $ 90��6F   $
��Bold"�6V   �� 53      -   5         ��Name$ txtEskiOlcubirimiAdi��53   `    �� 	MaxLength$	 255��6   $	��232��6&   $��24��62   $	 322��6>   $ 89��6P   $��18(�6~      MouseOverImageChange_Textbox#���  6�   {�.  6�   �� 55      $!��Ölçü Birimi Yeni Adı: *��6   $	 173��66   $	 118��6H   $
��Bold"�6Y   $	��132��6k   �� 56      -   5        $ txtYeniOlcuBirimiAdi��56   Q   $	��232��6   $	 322��6"   $	 118��64   $��25��6E   $��18(�6o   #���  6}   �� 5:      -   5         ��Name$ btn_OlcuBirimiGuncelle��5:   �     UrunEkleButonu#���  6   $	��414��6>   $��39��6J   $ ��Ölçü Birimini Güncelle��6V   $	 140��6x   $��0q�6�   $	 191��6�   6�   d� 5;      -   5         d�Name$ 	btn_Bilgi��5;   x     DaireButonbilgi#���  6   $	 559��6E   $ 17��6W   $ 3��6g   6�   �� 5<      -   5        $ btnKapat��5<   r     DaireButonCikis#���  6   $ 3��6?   $	 504��6P   $ 17��6b   ���	#FFEAEBF4$��2q�6�   � 5@      $	��318��6   $	��366��6    $	 484��6,   $ 17��6>   .+�5A      � -   5         �Name$ popup_bilgi��5A   +   $��Center=�6    � AllowsTransparency . $��Scroll=�6Z   .��5B      �� 
����  �$	��179��63   $	��225��6@   $ 
0,20,30,30��6L   ._�5C      �� $��7q�6%   .+�5D      �� $��Bilgilendirme Metni��6(   
�������$
��Bold"�6V   $��22(�6h   $��Center=�6v   �� 5E      -   5         ��Name$ txtBilgiPenceresi��5E   (   $
��Wrap=�6C   
�������$��0,10,0,0q�6j   5F      5G      5I      5L      5O      5P      5Q      