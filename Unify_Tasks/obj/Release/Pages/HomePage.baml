   M S B A M L   `   `   `  ���� F  BUnify_Tasks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Unify_Tasks.PagesUnify_Tasks.Pages       Unify_Tasks.Pages.HomePage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:Unify_Tasks.Pages     -   .��� -     �Name$  
layoutGrid�� � ColumnDefinitions �� $
��0.2* ��� $
��0.8* �.+�� -   $  sidepanelGrid��$��0�����#2f3136 � RowDefinitions �� $��0.025* ��� $��0.0575* �$
��46px���� $��0.01875* ��� $��0.0575* �$
��46px���� $��0.0475* ��� $��0.75* ��� $��0.04375* � �� $��0.08* ��� $��0.06* ��� $��0.72* ��� $��0.06* ��� $��0.08* �.+��� $��1��$��1��$��3��$��Stretch=�$��Stretch=�   MediumI#���    �� CornerRadius$ 10��._�� -   $  CardGrid�� �� $��0.025* ��� $��0.16* �$
��30px���� $��0.615* ��� $
��0.1* �$
��20px���� $��0.04* ��� $
��0.1* �$
��20px���� $��0.04* �.+��� -    ��Name$ 
AvatarRect��$��1��$��Center=�$��Center=�$��30��$��30��  CustomPurple#���   �� RadiusX$ 10�� �� RadiusY$ 10���� -    ��Name$ AvatarLetter��$��1��$��Center=�$��Center=� 	 MainI#���  $
��18px(�$��Medium"�$��Italic$�A�� -   $ UserNameBox��$��2��$
��Left=�$��Center=�$��10, 0, 10, 0q�#���  $
��22px(�$��Medium"�$�� ���� -   $��5��$��Center=�$��Center=�$��/Images/Exit.png�� �� BitmapScalingMode$ HighQuality=��� -	   	 ��Name$	 
NewProject��$��3��$��2��$��Stretch=�$��Stretch=�#���   $ 10��._��� $��Center=�$��Center=�$��New Project��$��Medium"�#���  $
��24px(��� -
   $��3��$��2��$��Stretch=�$��Stretch=�
 J� Opacity$
 0Q��� $��4��$��2��$
��12pt(�$��Light"�$��Center=�$��Bottom=�#���  
Projects�� $��5��$��1��$��3��#���   $ 10��._��� $��Visible=�.���� -    ��Name$ stackProjects��� -   $  mainpanelGrid��$��1��#���    �� $��0.0075* ��� $��0.075* �$
��60px���� $��0.075* �$
��60px���� $��0.05* ��� $��0.01* ��� $��0.7425* ��� $��0.0425* � �� $��0.04* ��� $��0.015* ��� $
��0.2* ��� $��0.015* ��� $
��0.2* ��� $��0.585* ��� $��0.09* ��� $��0.015* ��� $��0.04* �.+��� -    ��Name$ ProjectName��$��1��$��2��$��4��$
��Left=�$��Bottom=�$
��60px��#���  
������ $��0q�$��Medium"�$
��50px(�$�� ��$y�Hidden=� �� 	MaxLength$ 20��.���� -   $	 TasksViewer��$y�Hidden=�$��5��$��1��$��7�� 	 BackI#���  $ 10��._��� .���� -   $ 	TasksList���� -    ��Name$ TrashProject��$��1��$��6��$
��50px��$��/Images/Trashcan.png��$y�Hidden=�$��Stretch=�$��Stretch=�$ HighQuality=��� -   $ TrashRedProject��$y�Hidden=�$
 0Q�$��1��$��6��$
��50px��$��/Images/TrashcanRed.png��$��Stretch=�$��Stretch=�$ HighQuality=��� -   $	 NewTask��$��3��$��2��$��Stretch=�$��Stretch=�#���  $ 10��$y�Hidden=�._��� $��Center=�$��Center=�$��New Task��$��Light"�$��Italic$�#���  $
��22px(�