   M S B A M L   `   `   `  ����H  DSimulaceBanky, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SimulaceBankySimulaceBanky  5   	       SimulaceBanky.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:SimulaceBanky     5   	   -   5          � Title$  
MainWindow��5   	   {�. $��473.361��6-   $��803.689��6>   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFE8E8E8��6    � Offset$ 0Q�61   � 5      $ 	#FFECECEC��6   $ 1Q�61   5       � ColumnDefinitions 5   
   �� 5      $
��207* �6   6.   �� 5      $
��358* �6   6.   �� 5      $
��231* �6   6.   .+�5   
   �� -   5         ��Name$ 
tbl_penize��5      $��2��6(   $
��Left=�68   $��20��6S   $��	50,17,0,0q�6_   $
��Wrap=�6r   $��20000��6�   $	��Top=�6�   $��98��6�   $��Franklin Gothic Demi)�6�   $��18(�6�    �� TextAlignment$ Right=�6�   �� 5   
   -   5         ��Name$ tbl_plus��5      $��+��6#   $��2��6/   $
��Left=�6?   $��33��6Z   $��	183,9,0,0q�6f   $	��Top=�6y   $��38��6�   $��Franklin Gothic Demi)�6�   $��22(�6�   
����������	#FF4444446�   �� 5   
   -   5        $ 	tbl_minus��5      $��-��6$   $��2��60   $
��Left=�6@   $��33��6[   $��7,10,0,0q�6g   $	��Top=�6y   $��38��6�   $��Franklin Gothic Demi)�6�   $��22(�6�   
����������	#FF4444446�   �� 5   
   $
��Left=�6   $��33��6/   $��10,9,0,0q�6;   $
��Wrap=�6M   $��Uživatelský přehled��6a   $	��Top=�6|   $	��330��6�   $��Franklin Gothic Demi)�6�   $��30(�6�   $ Center=�6�   $��1��6�   	 J� RenderTransformOrigin$	 	0.3,0.295&�6�   �� 5   
   -   5        $ 	tbl_datum��5      $��27��6'   $��	10,16,0,0q�63   $
��Wrap=�6F   $��
21.10.2020��6Z   $	��Top=�6l   $��Franklin Gothic Book)�6�   $��20(�6�   $
��Left=�6�   $	��108��6�   �� 5   
   -   5        
 ��Name$
 st��5      $
��Left=�6!   $	��364��6<   $��	10,68,0,0q�6I   $	��Top=�6\   $	��776��6t   $��3��6�   .+�5      �� -   5        $ b_add��5      $��Založit účet��6$   $��0, 0, 0, 10q�6;   ���	#FF444444$��Franklin Gothic Medium)�6g   $��22(�6�   
�������$��30��6�   5      �� 5   
   $��2��6   $
��Left=�6$   $��20��6?   $��
148,17,0,0q�6K   $
��Wrap=�6_   $	��Kč��6s   $	��Top=�6}   $��25��6�   $��Franklin Gothic Demi)�6�   $��18(�6�   $ Center=�6�   �� 5   
   -   5        $ tbl_plusDatum��5      $��+��6(   $
��Left=�64   $��33��6O   $��
123,10,0,0q�6[   $	��Top=�6o   $��38��6�   $��Franklin Gothic Demi)�6�   $��22(�6�   
����������	#FF4444446�   5      5       