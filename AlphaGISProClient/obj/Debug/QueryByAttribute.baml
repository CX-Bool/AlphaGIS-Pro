   M S B A M L   `   `   `  ����  AlphaGISProClient&     AlphaGISProClient.QueryAttribute   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  按属性查询��5   	   $��502.271��6   $��486.045��6(   .��5      �  � ColumnDefinitions 5   
   �� 5      .+�5	   
   �� $��选择图层：��6   $
��Left=�6    $��	10,14,0,0q�6;   $	��Top=�6N   $��14(�6f   �� 5
   
   -   5         ��Name$ comboBox��5
      $
��Left=�6%   $��	95,20,0,0q�6@   $	��Top=�6S   $	��172��6k   6w   �� 5   
   -   5         ��Name$ 	fieldList��5      $
��Left=�6%   $	��169��6@   $��
10,116,0,0q�6M   $	��Top=�6a   $	��257��6y   6�   �� 5   
   $��可选字段：��6   $
��Left=�6    $��	10,88,0,0q�6;   $	��Top=�6N   $��14(�6f   �� 5   
   -   5        $ 	valueList��5      $
��Left=�6%   $	��142��6@   $��283,116,0,0q�6M   $	��Top=�6b   $	��186��6z   $��2��6�   �� 5   
   -   5        $��显示该字段所有值��5      $
��Left=�6$   $��283,263,0,0q�6?   $	��Top=�6T   $	��117��6l   $��2��6x   6�   �� 5   
   -   5        $��=��5      $
��Left=�6   $��
10,303,0,0q�68   $	��Top=�6L   $��32��6d   6o   �� 5   
   -   5        $��>��5      $
��Left=�6    $��
10,330,0,0q�6;   $	��Top=�6O   $��32��6g   6r   �� 5   
   -   5        $��<��5      $
��Left=�6    $��
10,357,0,0q�6;   $	��Top=�6O   $��32��6g   6r   �� 5   
   -   5        $��<>��5      $
��Left=�6$   $��
47,303,0,0q�6?   $	��Top=�6S   $��32��6k   6v   �� 5   
   -	   5        $	��≥��5      $
��Left=�6   $��
47,330,0,0q�68   $	��Top=�6L   $��32��6d   6o   �� 5   
   -
   5        $	��≤��5      $
��Left=�6   $��
47,357,0,0q�68   $	��Top=�6L   $��32��6d   6o   �� 5   
   -   5        $	��( )��5      $
��Left=�6   $��
10,384,0,0q�6:   $	��Top=�6N   $��32��6f    J� RenderTransformOrigin$ 0.594,2.227&�6q   6�   �� 5   
   -   5        $	��and��5      $
��Left=�6   $��
47,384,0,0q�6:   $	��Top=�6N   $��32��6f   $ 0.594,2.227&�6q   6�   �� 5   
   -   5        $
��like��5      $
��Left=�6    $��
84,303,0,0q�6;   $	��Top=�6O   $��32��6g   $ 0.594,2.227&�6r   {�.  6�   �� 5   
   -   5        $��is��5      $
��Left=�6   $��
84,330,0,0q�69   $	��Top=�6M   $��32��6e   $ 0.594,2.227&�6p   {�.  6�   �� 5   
   -   5        $	��not��5      $
��Left=�6   $��
84,357,0,0q�6:   $	��Top=�6N   $��32��6f   $ 0.594,2.227&�6q   6�   �� 5   
   -   5        $��or��5      $
��Left=�6   $��
84,384,0,0q�69   $	��Top=�6M   $��32��6e   $ 0.594,2.227&�6p   6�   �� 5   
   -   5         ��Name$ textBox��5      $
��Left=�6#   $��54��6>   $��134,325,0,0q�6J    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��335��6�   $��2��6�   �� 5   
   -   5        $��清空��5      $
��Left=�6   $��134,384,0,0q�69   $	��Top=�6N   $��42��6f   6q   �� 5   
   $��检验��6   $
��Left=�6   $��181,384,0,0q�69   $	��Top=�6N   $��42��6f   �� 5   
   $��SELECT * FROM  ___  WHERE��6   $
��Left=�64   $��134,299,0,0q�6O   $	��Top=�6d   �� 5    
   -   5         ��Name$ btnApply��5       $��应用��6#   $
��Left=�60   $��233,440,0,0q�6K   $	��Top=�6`   $��75��6x   6�   �� 5!   
   -   5        $ btnOk��5!      $��确定��6    $
��Left=�6-   $��313,440,0,0q�6H   $	��Top=�6]   $��75��6u   $��2��6�   6�   �� 5%   
   $��选择图层：��6   $
��Left=�6    $��	10,14,0,0q�6;   $	��Top=�6N   $��14(�6f   �� 5&   
   -   5        $ 	layerList��5&      $
��Left=�6&   $��	95,20,0,0q�6A   $	��Top=�6T   $	��172��6l   6x   5(      5)      