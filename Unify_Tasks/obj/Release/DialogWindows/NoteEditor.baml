   M S B A M L   `   `   `  ���� F  BUnify_Tasks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Unify_Tasks.DialogWindowsUnify_Tasks.DialogWindows  *    $Unify_Tasks.DialogWindows.NoteEditor   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9local'clr-namespace:Unify_Tasks.DialogWindows     -     � Title$  
NoteEditor��$	��450��$	��800�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ 
ToolWindow=� � 
ResizeMode$ NoResize=�.���  	  BackI#���    � RowDefinitions �� $��0.08* ��� $��0.78* ��� $��0.14* �.+�`� $
��35px��$��0��$	��Top=� `� 
Background# �   .�c� $
��35px��  MediumI#���   	 MainI#���  .@�d� -    d�Name$ 
BoldButton��$��4 0 4 0q�$��
5, 0, 5, 0q�$��22(�.��Bd� -   $ ItalicButton��$��4 0 4 0q�$��
5, 0, 5, 0q�$��22(�$��Italic$�.��Id� -   $ UnderlineButton��$��22(�$��
5, 0, 5, 0q�$��4 0 4 0q�.���� $��	Underline{�U�� -   $��	FontColor��$��4 0 25 0q�$��10, 0, 10, 0q�$��0q�  ComboBoxTemplate1#���  .@���  �� 
IsSelected . .���� �� 
�������$��10��$��10�� White�� .���� �� 
�������$��10��$��10�� Gray�� .���� �� 
���  ��$��10��$��10�� Red�� .���� �� 
����  �$��10��$��10�� Blue�� .���� �� 
��� � �$��10��$��10�� Green�� .���� �� 
���� ��$��10��$��10��	 Purple�� -   $��	FontStyle��$��4 0 25 0q�$��10, 0, 10, 0q�  AccentI#���  $��0q�.@���  . .���� 	Main font�� .���� 
Header 1�� .���� 
Header 2�� .���� 
Header 3�� -    ��Name$ NoteText��$��1��
�������$��/Fonts/#Gilroy)�$��Normal"�$��14(�#���  $��5q��� -   $��2��$��200px��$
��50px��#���  	 �� CornerRadius$	 10��._��� 
�������$��Center=�$��Center=�$��Medium"�$��24(�$��Save changes��