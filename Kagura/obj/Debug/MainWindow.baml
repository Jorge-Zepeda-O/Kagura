   M S B A M L   `   `   `  ����A  =Kagura, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KaguraKagura  5   	       Kagura.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Kagura     5   	     � Title$  Kagura��5   	   $	��400��6   $	��600��6%   .��5	      �  � RowDefinitions 5
   
   �� 5      $��20 �6   �� 5      $��30 �6   �� 5      $��40 �6   �� 5      $��20 �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6!    �� TextAlignment$ Right=�61   "Songs" folder :6Y   �� 5   
   -   5        $��	SongsPath��5   C   $��0��6   $��1��6   $��2��6/   .��6T   $"A:\Games\Stepmania 5.0.12\Testing\6x   d� 5   
   -   5        $��BtnDebug��5   4   $��1��6   $��0��6$   .��6D   
Debug Mode6P   d� 5   
   -   5        $��BtnWrite��5   4   $��1��6   $��1��6$   .��6D   Overwrite Files6U   d� 5   
   -   5        $��BtnStats��5   4   $��1��6   $��2��6$   .��6D   
Save Stats6P   �� 5   
   -   5        $��2��5      $��1��6   .��6@   
Rate Songs6L   � 5   
   -   5        $��Progress��5   7   $��3��6   $��3��6#    � Value$ 0Q�6G   6S   �� 5   
   -   5        $��	PacksDone��5   6   $��3��6   $��3��6!   $ Center=�6G   6`   �� 5   
   -   5        $��Output��5   4   $��4��6   $��3��6   $��Consolas)�6B   $��20(�6X   6h   5      5       