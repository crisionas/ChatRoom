   M S B A M L   `   `   `  ����J  FRoomChatsClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:RoomChatsClient.ViewsRoomChatsClient.Views  5   	   &     RoomChatsClient.Views.ChatWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:RoomChatsClient.Views     5   	     � SizeToContent$  WidthAndHeight=�5   	    � 
ResizeMode$ NoResize=�5	   	    � Title$ 
ChatWindow��5
   	   $	��450��6   $	��800��6)   .��5      � .+�5   
   �� -   5        $��userlist��5      $��20,20,630,16q�6"   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6P   ��68   �� 6u   �� 5   
   -   5        $��	chatrooms��5      $��185,20,150,390q�6$   4  .System.Windows.Automation.AutomationProperties   HelpText$ default��6j   �� 5   
   -   5         ��Name$ messages��5      $��Stretch=�6=   $	��310��6[   $��185,60,20,55q�6i   $��Stretch=�6   $	��600��6�   $
 TrueY�6�   ��6%   �� 6�   �� 5   
   -   5        $��messageTextBox��5       �� TextWrapping$
 Wrap=�6(   $��185,390,89,16q�6<   6S   �� 5   
   -   5        $��createChatroomButton��5      $��Create chatroom��6-   $
��Auto��6G   $
��Auto��6U   $��665,20,20,390q�6b   6y   �� 5   
   -   5        $��
sendButton��5      $
��Send��6#   $
��Auto��62   $
��Auto��6@   $��716,390,20,16q�6M   6d   �� 5   
   -   5        $��nicknameBox��5      $
��Left=�6'   $��20,0,0,0q�6B   $��	TextBlock��6T   $
��Wrap=�6e   $	��Top=�6y   5      5      