   M S B A M L   `   `   `  ����N  JStokTakipUygulamasi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:StokTakipUygulamasi.PencerelerStokTakipUygulamasi.Pencereler  5   	   ;    5StokTakipUygulamasi.Pencereler.ToptanciSilmePenceresi   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:StokTakipUygulamasi.Pencereler     5   	     � Title$  ToptanciSilmePenceresi��5   	   $��374.8��6(   $��677.6��67    � AllowsTransparency .  � WindowStyle$
 None=�6u    � WindowStartupLocation$ CenterScreen=�6�   ��6E   Z� .��5	      � .+�5
   
   �� .+�5      �� $��/images/icons/sil.png��6    �� Left$ 90��63   $��58��6D   
 �� Top$ 41��6P   $��54��6`    K� ZIndex$ 3                    ��6k   �� 5      $ ��TOPTANCI SİLME PENCERESİ��6   $
��Bold"�67   $��18(�6I   $	 173��6W   $ 23��6i   $ 3��6y   ���	#FFF6EDED$��35��6�   $��Center=�6�   $��Center=�6�      Label_yanip_sonme_efekti#���   6�   �� 5      $��35��6   $	��469��6$   $	 103��60   $ 23��6B   ���	#FF134187$ 1��6c   A� 5      $	��118��6   $	��115��6#   $ 58��6/   $ 10��6@   $ 2��6P   $��4��6a    J� RenderTransformOrigin$ 0.5,0.5&�6u     donme_efekti#���  6�   z�5      �� 5      ��5      �� 5       �� EndPoint$ 0.5,1&�6*   	 �� 
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
 0.35Q�65   5"      5$      �� 5&      $	��469��6   $	��324��6!   $	 103��6.   $ 23��6@    �� CornerRadius$ 	0,0,50,50��6P   ���	#FFE0E0E0 J� Effect 5'      3  -System.Windows.Media.Effects.DropShadowEffect  5(         Opacity$
 0.35Q�6'      	Direction$	 275Q�66   5*      �� 5.      $'��!Silinme Sebebi (İsteğe Bağlı)��6   $	 178��6<   $ 72��6N   $
��Bold"�6^   �� 5/      -   5         ��Name$ txtSilmeSebebi��5/   v    �� TextWrapping$
 Wrap=�6    �� 	MaxLength$	 255��6*   $	��365��6:   $	��142��6F   $	 173��6S   $	 103��6e   $��18(�6�      MouseOverImageChange_Textbox#���  6�   �� 54      -   5         ��Name$ btn_Toptanciyi_Sil��54   �     UrunEkleButonu#���  6   $	��365��6>   $��57��6J   $��Toptancıyı Sil��6V   $	 173��6p   $��0q�6�   $	 266��6�   6�   d� 55      -   5         d�Name$ 	btn_Bilgi��55   x     DaireButonbilgi#���  6   $	 518��6E   $ 16��6W   $ 3��6g   6�   �� 56      -   5        $ btnKapat��56   r     DaireButonCikis#���  6   $ 3��6?   $	 464��6P   $ 17��6b   ���	#FFEAEBF4$��2q�6�   � 5:      $	��318��6   $	��366��6    $	 472��6,   $ 5��6>   .+�5;      � -   5         �Name$ popup_bilgi��5;   +   $��Center=�6    � AllowsTransparency . $��Scroll=�6Z   .��5<      �� 
����  �$	��179��63   $	��225��6@   $ 
0,20,30,30��6L   ._�5=      �� $��7q�6%   .+�5>      �� $��Bilgilendirme Metni��6(   
�������$
��Bold"�6V   $��22(�6h   $��Center=�6v   �� 5?      -   5         ��Name$ txtBilgiPenceresi��5?   (   $
��Wrap=�6C   
�������$��0,10,0,0q�6k   5@      5A      5C      5F      5I      5J      5K      