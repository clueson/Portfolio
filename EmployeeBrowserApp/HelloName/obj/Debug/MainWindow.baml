   M S B A M L   `   `   `  ����P  LHelloName, Version=1.0.0.0, Culture=neutral, PublicKeyToken=6bb996788d91c746%clr-namespace:HelloName	HelloName  5   	       HelloName.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:HelloName     5   	     � Title$  WPF Client Service��5   	   
���   �$��2q�68   $	��375��6L   $	��280��6Y    � WindowStartupLocation$ CenterScreen=�6e    � WindowStyle$
 None=�6�    � SizeToContent$ WidthAndHeight=�6�    � 
ResizeMode$ NoResize=�6�   .��5	      ��  �� Orientation$ Vertical=�6   $��2q�6(   .+�5
   
   �� -   5         ��Name$ lblTitle��5
      $��25��6"   $	��170��6.   $��2,10,2,2q�6:   $!��Send Your Name to a Service��6L   $��Italic$�6r   $
��Bold"�6�   6�   �� 5      $ 
Horizontal=�6   $��5q�62   .+�5      �� -   5        $ lblEntertext��5      $��2q�6/   $��	Your Name��6:   6P   �� 5      -   5         ��Name$ tbxName��5      $��20��6+   $	��125��67   $��5,2,2,2q�6C   $��Type your name here��6T   6q   5      �� 5   
   -   5         ��Name$ 	btnSubmit��5      $��25��6$   $	��100��60   $��2,2,2,2q�6<   $��Submit��6M   6y   �� 5   
   $ 
Horizontal=�6   $��5q�6.   .+�5      �� -   5        $ lblReceivedText��5      $��Received Text��6-   $��2q�6E   6R   �� 5      -   5        	 ��Name$	 
tbkMessage��5      $��Center=�6,   $��2q�6G   6T   5      �� 5   
   $ Vertical=�6   $��5q�6,   .+�5      �� -   5        $ lblErrorMessage��5      $��Error��6-   $��2q�6=   6J   �� 5      -   5        
 ��Name$
 bdrScrollViewer��5      
���   �$��1q�6B    �� CornerRadius$ 5��6V   $��5q�6g   ._�5      �� -	   5         ��Name$ srvErrorMessage��5      $
��auto��5      $	��240��5      $��Italic$�5      
���  ��
�������$��Visible=�5      $��5q�5      .��5      �� -
   5        $	 tbxErrorMessage��5       $
��auto��69    �� LineStackingStrategy$ BlockLineHeight=�6G   6z   5       5!      5"      �� 5#   
   -   5        $ btnClose��5#      $��25��6#   $��75��6/   $��Close��6:   $��10q�6J   6o   5$      5%      