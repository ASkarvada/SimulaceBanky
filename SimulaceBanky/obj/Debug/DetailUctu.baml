   M S B A M L   `   `   `  ����H  DSimulaceBanky, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SimulaceBankySimulaceBanky  5   	       SimulaceBanky.DetailUctu   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:SimulaceBanky     5   	   -   5          � Title$  
DetailUctu��5   	   $	��464��6   $	��800��6)   .��5	      � 
�������.+�5
   
   �� -   5         ��Name$ 	tbl_jmeno��5
      $
��Left=�6'   $��33��6B   $��	10,10,0,0q�6N   $
��Wrap=�6a   $��Spořící účet��6u   $	��Top=�6�   $	��772��6�   $��Franklin Gothic Demi)�6�   $��30(�6�    �� TextAlignment$ Center=�6�   �� 5   
   -   5        $ 	tbl_popis��5      $
��Left=�6'   $	��155��6B   $��	10,54,0,0q�6O   $
��Wrap=�6b   $	��Top=�6v   $	��392��6�   $��Franklin Gothic Medium)�6�   $��16(�6�   �� 6�   $�Typ účtu:��6�   �� 6�   �� 6�   $�Úročení:��6�   �� 6  �� 6  $�Omezenost výběru:��6  �� 61  �� 6=  $�Od kdy do kdy - ��6A  �� 6[  $�kolikátá ��6_  �� 6r  $�splátka��6v  6�  �� 5   
   $
��Left=�6   $��28��6/   $��468,162,0,0q�6;   $
��Wrap=�6P   $	��Top=�6d   $	��157��6|   $��Franklin Gothic Demi Cond)�6�   $��22(�6�   $��Aktuální částka:��6�   �� 5   
   $
��Left=�6   $��28��6/   $��
10,214,0,0q�6;   $
��Wrap=�6O   $	��Top=�6c   $	��453��6{   $��Franklin Gothic Demi Cond)�6�   $��22(�6�   �� 6�   $�Historie vkladů��6�   �� 6�   $�, ��6�   �� 6�   $�	výběrů��6�   �� 6�   $�
 a úroků��6  �� 6  $�:��6  6$  �� 5   
   -   5        $ 
tbl_castka��5      $
��Left=�6(   $��23��6C   $��630,164,0,0q�6O   $
��Wrap=�6d   $	��Top=�6x   $	��123��6�   $��Franklin Gothic Demi Cond)�6�   $��20(�6�   $��15000��6�   $ Right=�6�   �� 5   
   -   5         ��Name$ b_vyber��5      $��VÝBĚR��6"   $
��Left=�62   $��39��6M   $��
468,64,0,0q�6Y   $	��Top=�6m   $	��314��6�   ���	#FF444444
�������$��Franklin Gothic Medium)�6�   $��14(�6�   6�   �� 5   
   -   5        $ b_vklad��5      $��VKLAD��6"   $
��Left=�62   $��39��6M   $��468,108,0,0q�6Y   $	��Top=�6n   $	��314��6�   ���	#FF444444
�������$��Franklin Gothic Medium)�6�   $��14(�6�   6�   �� 5   
   -   5         ��Name$ tbl_historie��5      $
��Left=�6(   $	��181��6C   $��
10,242,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $����21.10.2020 - vklad - 15000Kč	Můj první vklad
21.10.2020 - vklad - 15000Kč	Můj první vklad
21.10.2020 - vklad - 15000Kč	Můj první vklad
21.10.2020 - vklad - 15000Kč	Můj první vklad
21.10.2020 - vklad - 15000Kč	Můj první vklad
��6x   $	��Top=�6�  $	��772��6�  $��Franklin Gothic Book)�6�  $��16(�6�  �� 5   
   $
��Left=�6   $��23��6/   $��758,164,0,0q�6;   $
��Wrap=�6P   $	��Top=�6d   $��24��6|   $��Franklin Gothic Demi Cond)�6�   $��20(�6�   $	��Kč��6�   �� 5   
   -   5        $ tbl_moznostText��5      $
��Left=�6-   $��28��6H   $��468,195,0,0q�6T   $
��Wrap=�6i   $	��Top=�6}   $	��157��6�   $��Franklin Gothic Demi Cond)�6�   $��22(�6�   $��Možnost výběru:��6�   �� 5   
   -	   5        $ tbl_moznostCastka��5      $
��Left=�6/   $��23��6J   $��630,197,0,0q�6V   $
��Wrap=�6k   $	��Top=�6   $	��123��6�   $��Franklin Gothic Demi Cond)�6�   $��20(�6�   $��15000��6�   $ Right=�6�   �� 5   
   -
   5        $ tbl_moznostText2��5      $
��Left=�6.   $��23��6I   $��758,197,0,0q�6U   $
��Wrap=�6j   $	��Top=�6~   $��24��6�   $��Franklin Gothic Demi Cond)�6�   $��20(�6�   $	��Kč��6�   �� 5   
   -   5        $ b_zrusit��5      $y�Visible=�6#   $��ZRUŠIT ÚČET��68   $
��Left=�6N   $��32��6i   $��
655,10,0,0q�6u   $	��Top=�6�   $	��127��6�   ���	#FF444444
�������$��Franklin Gothic Medium)�6�   $��14(�6�   6	  5      5      