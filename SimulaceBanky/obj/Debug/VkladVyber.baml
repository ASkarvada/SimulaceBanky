   M S B A M L   `   `   `  ����H  DSimulaceBanky, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SimulaceBankySimulaceBanky  5   	       SimulaceBanky.VkladVyber   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:SimulaceBanky     5   	     � Title$  
VkladVyber��5   	   $��472.339��6   $��562.704��6-   .��5	      � .+�5
   
   �� -   5         ��Name$ 	tbl_jmeno��5
      $
��Left=�6'   $��33��6B   $��	10,10,0,0q�6N   $
��Wrap=�6a   $��Vklad/Výběr��6u   $	��Top=�6�   $	��535��6�   $��Franklin Gothic Demi)�6�   $��30(�6�    �� TextAlignment$ Center=�6�   �� 5   
   $
��Left=�6   $��28��6/   $��	10,72,0,0q�6;   $
��Wrap=�6N   $	��Top=�6b   $	��253��6z   $��Franklin Gothic Demi Cond)�6�   $��22(�6�   �� 6�   $�Aktuální částka��6�   �� 6�   $�
 na účtu��6�   �� 6�   $�:��6�   6�   �� 5   
   $
��Left=�6   $��28��6/   $��
10,105,0,0q�6;   $
��Wrap=�6O   $	��Top=�6c   $	��253��6{   $��Franklin Gothic Demi Cond)�6�   $��22(�6�   �� 6�   $�Peněz celkem ��6�   �� 6�   $�v hotovosti:��6�   6�   �� 5   
   -   5        $ tbl_castkaUcet��5      $
��Left=�6,   $��28��6G   $��
283,72,0,0q�6S   $
��Wrap=�6g   $	��Top=�6{   $	��221��6�   $��Franklin Gothic Medium)�6�   $��22(�6�   $ Right=�6�   �� 5   
   -   5        $ tbl_castkaHotovost��5      $
��Left=�60   $��28��6K   $��283,105,0,0q�6W   $
��Wrap=�6l   $	��Top=�6�   $	��221��6�   $��Franklin Gothic Medium)�6�   $��22(�6�   $ Right=�6�   �� 5   
   -   5        $ tbl_zadejteText��5      $
��Left=�6-   $��28��6H   $��
10,164,0,0q�6T   $
��Wrap=�6h   $	��Top=�6|   $	��253��6�   $��Franklin Gothic Demi Cond)�6�   $��22(�6�   $#��Zadejte částku pro výběr:��6�   �� 5   
   -   5         ��Name$ tbl_castkaVyberu��5      $
��Left=�6,   $��32��6G   $��281,163,0,0q�6S    �� TextWrapping$
 Wrap=�6h   $	��Top=�6|   $	��223��6�   $��22(�6�   $��Franklin Gothic Book)�6�   �� 5   
   $
��Left=�6   $��28��6/   $��509,165,0,0q�6;   $
��Wrap=�6P   $	��Top=�6d   $��36��6|   $��Franklin Gothic Demi Cond)�6�   $��22(�6�   $	��Kč��6�    J� RenderTransformOrigin$ 0.475,-1.737&�6�   �� 5   
   -   5         ��Name$ b_vkladVyber��5      $��VÝBĚR/VKLAD��6'   $
��Left=�6=   $��54��6X   $��
10,377,0,0q�6d   $	��Top=�6x   $	��348��6�   ���	#FF444444
�������$��Franklin Gothic Medium)�6�   $��16(�6�   6�   �� 5   
   -   5        $ b_zrusit��5      $��ZRUŠIT��6#   $
��Left=�64   $��54��6O   $��363,377,0,0q�6[   $	��Top=�6p   $	��182��6�   ���	#FF444444
�������$��Franklin Gothic Medium)�6�   $��16(�6�   6�   �� 5   
   $
��Left=�6   $��28��6/   $��
10,200,0,0q�6;   $
��Wrap=�6O   $	��Top=�6c   $	��171��6{   $��Franklin Gothic Medium)�6�   $��20(�6�   $��Omezenost výběru:��6�   �� 5   
   -   5        $ tbl_omezenost��5      $
��Left=�6+   $��66��6F   $��186,200,0,0q�6R   $
��Wrap=�6g   $	��Top=�6{   $	��359��6�   $��Franklin Gothic Medium)�6�   $��20(�6�   $��Ano - částka / Ne��6�   �� 5   
   -	   5        $ tbl_zadejteText_Copy��5      $
��Left=�62   $��28��6M   $��
10,271,0,0q�6Y   $
��Wrap=�6m   $	��Top=�6�   $	��253��6�   $��Franklin Gothic Demi Cond)�6�   $��22(�6�   $��Zadejte poznámku:��6�   �� 5   
   -
   5        $ tbl_poznamka��5      $
��Left=�6(   $��59��6C   $��
10,299,0,0q�6O   $
 Wrap=�6c   $	��Top=�6w   $	��535��6�   $��18(�6�   $��Franklin Gothic Book)�6�   �� 5   
   $
��Left=�6   $��28��6/   $��509,105,0,0q�6;   $
��Wrap=�6P   $	��Top=�6d   $��36��6|   $��Franklin Gothic Demi Cond)�6�   $��22(�6�   $	��Kč��6�   $ 0.475,-1.737&�6�   �� 5   
   $
��Left=�6   $��28��6/   $��
509,72,0,0q�6;   $
��Wrap=�6O   $	��Top=�6c   $��36��6{   $��Franklin Gothic Demi Cond)�6�   $��22(�6�   $	��Kč��6�   $ 0.475,-1.737&�6�   5      5      