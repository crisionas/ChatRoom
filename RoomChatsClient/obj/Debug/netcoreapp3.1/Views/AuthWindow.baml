   M S B A M L   `   `   `  ����J  FRoomChatsClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:RoomChatsClient.ViewsRoomChatsClient.Views  5   	   &     RoomChatsClient.Views.AuthWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:RoomChatsClient.Views     5   	     � SizeToContent$  WidthAndHeight=�5   	    � 
ResizeMode$ NoResize=�5   	    � Title$ 
AuthWindow��5
      $	��390��6$   $	��450��61   .��5      � $��Stretch=�6   $
��Auto��6)   $��0,0,0,0q�67   $��Stretch=�6H   $
��Auto��6d   .+�5   
   ��  �� Orientation$ Vertical=�6   $
��Auto��6,   $��
60,13,60,6q�69   .+�5      �� $��
60,13,60,0q�6   $
��Wrap=�6,   $��Welcome��6@   $��Stretch=�6O   $
��Auto��6k   $��30(�6x   $
��Bold"�6�    �� TextAlignment$ Center=�6�   �� 5      $��
60,13,60,0q�6   $
��Wrap=�6,   $��Stretch=�6@   $
��Auto��6\   $ Center=�6i   $��17(�6�   �� 6�   $�Username��6�   �� 6�   $�:��6�   6�   �� 5      -   5        $��usernameTextBox��5      $��
60,13,60,0q�6/    �� TextWrapping$
 Wrap=�6C   $��38��6�   $��14(�6�   ��6W   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      $��
60,13,60,0q�6   $
��Wrap=�6,   $��	Password:��6@   $��Stretch=�6Q   $
��Auto��6m   $��17(�6z   $ Center=�6�   $
��Auto��6�   G� 5      -   5        $��passwordTextBox��5      $��32��61   $��
60,13,60,0q�6=   $��14(�6Q   �� 5      $ Vertical=�6   $
��Auto��60   $��
60,13,60,0q�6>   �� 5      -   5        $��loginButton��5      $��Login��6(   $��
60,13,60,0q�68   $
��Auto��6L   $��32��6n   �� 5      -   5        $��registerButton��5      $��Register��6+   $��
60,13,60,0q�6>   $
��Auto��6R   $��32��6v   � 5      $��
60,13,60,0q�6   � 5      $	��100��6   $��	60,0,60,0q�6    5      5      5      