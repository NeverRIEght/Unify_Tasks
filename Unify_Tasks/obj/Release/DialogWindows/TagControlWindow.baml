   M S B A M L   `   `   `  ���� F  BUnify_Tasks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Unify_Tasks.DialogWindowsUnify_Tasks.DialogWindows  0    *Unify_Tasks.DialogWindows.TagControlWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9local'clr-namespace:Unify_Tasks.DialogWindows     -     � Title$  Assign Tags��$	��480��$	��500�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ 
ToolWindow=� � 
ResizeMode$ NoResize=� � 	Resources  �� 
TargetType �� Property �� Value 	  MainI��%  '��       '�� C     �� " ��.���  � ��$ /Fonts/#Gilroy)���  � ��# �   �� " ��.���  � ��$ /Fonts/#Gilroy)���  � ��
 �������  � ��
 ���� ��  � ��$ 0q���  �@��	MaxLength$ 24����  � ��$ 280px��.���  � RowDefinitions �� $��0.125* ��� $��0.875* �.+�� $��0��  MediumI#���  	 � ColumnDefinitions	 �� �� .+��� $��0��$��Center=�$��Center=�$��24(�$��Medium"�Edit or create tag�� $��1��$��Center=�$��Center=�$��24(�$��Medium"�Tags for this task� $��1�� 	 BackI#���  	 �� �� .+�� -   
 �Name$
 LeftGrid��$��0�� �� $��0.05* ��� $��0.21* ��� $��0.05* ��� $��0.05* ��� $��0.42* ��� $��0.125* �	 �� $��0.015* ��� $��0.45* ��� $��0.07* ��� $��0.45* ��� $��0.015* �.+��� $��1��$��1��$
��Left=�$	��Top=�$��20(�$��Medium"�Name�� -    ��Name$ TagNameBorder��$��1��$��1��$��3��$
��Left=�$��Bottom=�$
��50px�� �� CornerRadius$ 10��  AccentI#���   J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 20Q�   Color$ Black��   Opacity$	 0.5Q�._��� -    ��Name$ 
TagNameBox��$
��Left=�$��Center=�$��10, 0, 10, 0q�$��Medium"�$
��18px(� �� 	MaxLength$ 12��$��Tag Name��.���� $��3��$��1��$
��Left=�$	��Top=�$��20(�$��Medium"�Color�� $��4��$��1��
������ $ 10��   $ 20Q�$ Black��$	 0.5Q�._��� -    ��Name$ 
ColorBoard��$
��Left=�.+��� -   $ Border1��$
��20px��$��100px��#���  $��
0, 5, 0, 5q�$ 10��._��� $��Medium"�$
��18px(�$��10, 0, 10, 0q�$��Center=�  	CustomRed#���  Red�� -   $ Border2��$
��20px��$��100px��#���  $��
0, 5, 0, 5q�$ 10��._��� $��Medium"�$
��18px(�$��10, 0, 10, 0q�$��Center=�  CustomGreen#���  Green�� -   $ Border3��$
��20px��$��100px��#���  $��
0, 5, 0, 5q�$ 10��._��� $��Medium"�$
��18px(�$��10, 0, 10, 0q�$��Center=�  
CustomBlue#���  Blue�� -	   $ Border4��$
��20px��$��100px��#���  $��
0, 5, 0, 5q�$ 10��._��� $��Medium"�$
��18px(�$��10, 0, 10, 0q�$��Center=�  CustomBrown#���  Brown�� $��4��$��3��
������ $ 10��   $ 20Q�$ Black��$	 0.5Q�._��� -
   $ ColorBoard2��$
��Left=�.+��� -   $ Border5��$
��20px��$��100px��#���  $��
0, 5, 0, 5q�$ 10��._��� $��Medium"�$
��18px(�$��10, 0, 10, 0q�$��Center=�  
CustomGray#���  Gray�� -   $ Border6��$
��20px��$��100px��#���  $��
0, 5, 0, 5q�$ 10��._��� $��Medium"�$
��18px(�$��10, 0, 10, 0q�$��Center=� 	 CustomYellow#��� 	 Yellow�� -   $ Border7��$
��20px��$��100px��#���  $��
0, 5, 0, 5q�$ 10��._��� $��Medium"�$
��18px(�$��10, 0, 10, 0q�$��Center=� 
 
CustomPink#��� 
 Pink�� -   $ Border8��$
��20px��$��100px��#���  $��
0, 5, 0, 5q�$ 10��._��� $��Medium"�$
��18px(�$��10, 0, 10, 0q�$��Center=�  CustomPurple#���  Purple�� -   $ DelTag��$��5��$��1��$��Center=�$��Center=�$
��30px��$��100px��$ 10��#���     $ 20Q�$ Black��$	 0.5Q�._��� $��Center=�$��Center=�$��
Delete Tag��$��Light"�$��Italic$�$
��18px(��� -   $ SaveTag��$��5��$��3��$��Center=�$��Center=�$
��30px��$��100px��$ 10��#���     $ 20Q�$ Black��$	 0.5Q�._��� $��Center=�$��Center=�$��Save Tag��$��Light"�$��Italic$�$
��18px(�� -   $
 	RightGrid��$��1�� �� $��0.05* ��� $��0.73* ��� $��0.125* �	 �� $��0.015* ��� $��0.97* ��� $��0.015* �.+��� $��1��$��1��#���  $ 10��   $ 20Q�$ Black��$	 0.5Q�._��� -   $ 	TagsBoard��