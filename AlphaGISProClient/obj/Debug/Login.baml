   M S B A M L   `   `   `  ����L  HAlphaGISProClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:AlphaGISProClientAlphaGISProClient  5   	       AlphaGISProClient.Login   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:AlphaGISProClient     5   	     � Title$  用户登录��5   	   $��240.254��6   $��500         ��6'   .��5
      � .+�5   
   �� -   5         ��Name$ 	btnCancel��5      $��取消��6$   $
��Left=�61   $��399,157,0,0q�6L   $	��Top=�6a   $��74��6y   6�   �� 5   
   -   5        $ btnLogin��5      $��普通用户登录��6#   $
��Left=�64   $��275,157,0,0q�6O   $	��Top=�6d   $��76��6|   6�   �� 5   
   -   5        $ btnAdmin��5      $��管理员登录��6#   $
��Left=�63   $��156,157,0,0q�6N   $	��Top=�6c   $��76��6{   6�   �� 5   
   -   5         ��Name$ textboxServer��5      $
��Left=�6)   $��24��6D   $��
104,29,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $��	localhost��6x   $	��Top=�6�   $	��128��6�   �� 5   
   -   5         ��Name$ 
label_Copy��5      $��服务器地址��6$   $
��Left=�64   $��	18,27,0,0q�6O   $	��Top=�6b   $��76��6z   �� 5   
   -   5        $ textboxUsername��5      $
��Left=�6+   $��23��6F   $��
104,80,0,0q�6R   $
 Wrap=�6f   $��postgres��6z   $	��Top=�6�   $	��128��6�   �� 5   
   -   5        $ label_Copy1��5      $��	用户名��6%   $
��Left=�63   $��	18,78,0,0q�6N   $	��Top=�6a   $��65��6y   G� 5   
   -   5         G�Name$ textboxPassword��5      $
��Left=�6/   $��23��6J   $��
345,80,0,0q�6V   $	��Top=�6j   $	��128��6�   �� 5   
   -	   5        $ label_Copy2��5      $��密码��6%   $
��Left=�62   $��
275,78,0,0q�6M   $	��Top=�6a   $��65��6y   �� 5   
   -
   5        $ textboxPort��5      $
��Left=�6'   $��23��6B   $��
345,29,0,0q�6N   $
 Wrap=�6b   $
��2333��6v   $	��Top=�6�   $	��128��6�   �� 5   
   -   5        $ label_Copy4��5      $��端口��6%   $
��Left=�62   $��
275,28,0,0q�6M   $	��Top=�6a   $��65��6y   5      5      