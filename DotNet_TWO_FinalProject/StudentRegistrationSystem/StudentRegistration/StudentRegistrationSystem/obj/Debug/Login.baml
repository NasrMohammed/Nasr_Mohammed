   M S B A M L   `   `   `  ����  StudentRegistrationSystem%    StudentRegistrationSystem.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Login��5   	   $��204.06��6   $��386.175��6'    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $	��300 �6   .+�5   
   �� -   5         ��Name$ lblUsername��5      $��0��6%   $��0��62   $��
Username: ��6B   $��	0,0,188,0q�6W   �� 5   
   -   5        $ lblPassword��5      $��1��6%   $��0��62   $��
Password: ��6B   $��	0,0,188,0q�6W   �� 5   
   -   5        $ lblPassConfirm��5      $��2��6(   $��0��65   $��Confirm Password: ��6E   $y�Hidden=�6b   $��	0,0,188,0q�6v   �� 5   
   -   5         ��Name$ txtUsername��5      $��0��6'   $��	117,5,5,5q�64   G� 5   
   -   5         G�Name$ txtPassword��5      $��1��6+   $��	117,5,5,5q�68   G� 5   
   -   5        $ txtPassConfirm��5      $��2��6.   $��	117,5,5,5q�6;   $y�Hidden=�6N   � 5   
   $��3��6   $��	112,0,0,0q�6    5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� -   5         ��Name$ 	btnSubmit��5   %   $��0��6   $��Submit��69   $��	10 0 10 0q�6J   $��5q�6^    J� RenderTransformOrigin$ 0.503,0.509&�6i   6�   �� 5      -	   5        $ 	btnCancel��5   %   $��1��6   $��Cancel��69   $��	10 0 10 0q�6J   $��5q�6^   6i   5      �� 5   
   -
   5        	 ��Name$	 
chkNewUser��5      $��New User��6'   $
��Left=�6:   $��5,5,0,0q�6U   $��3��6f   $	��Top=�6s   6�   5      5       