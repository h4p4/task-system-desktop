   M S B A M L   `   `   `  ����E  ATaskSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TaskSystem.ViewsTaskSystem.Views  5   	   =#clr-namespace:TaskSystem.ViewModelsTaskSystem.ViewModels  66   #    TaskSystem.Views.SignUpWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:TaskSystem.Views     5   	   :
viewmodels#clr-namespace:TaskSystem.ViewModels     66     � Title$  SignUpWindow��5   	   $	��350��6   $	��210��6+   $��Italic$�5	   	   $��SemiBold"�5
   	   $	��350��5   	   $	��210��6   $	��350��5   	   $	��210��6    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5        $��NameTBox��5   `   $��0��6/   $��0��6<   $��3��6L   $	��160��6p   $��25��6|   $��Bottom=�6�   ��6   �� *NewUserName+6�   �� 5   
   -   5        $��SurnameTBox��5   c   $��1��62   $��0��6?   $��3��6O   $	��160��6v   $��25��6�   $��Bottom=�6�   ��6   �� *NewUserSurname+6�   �� 5    
   -   5        $��MidNameTBox��5    c   $��2��62   $��0��6?   $��3��6O   $	��160��6v   $��25��6�   $��Bottom=�6�   ��6   �� *NewUserMidName+6�   �� 5!   
   -   5        $��	PhoneTBox��5!   d   $��3��63   $��0��6@   $��3��6P   $	��160��6u   $��25��6�   $��Bottom=�6�   ��6   �� *NewUserPhoneNum+6�   �� 5"   
   -   5        $��	LoginTBox��5"   a   $��4��60   $��0��6=   $��3��6M   $	��160��6r   $��25��6~   $��Bottom=�6�   ��6   �� *NewUserLogin+6�   �� 5#   
   -   5        $��PassPBox��5#   d   $��5��63   $��0��6@   $��3��6P   $	��160��6t   $��25��6�   $��Bottom=�6�   ��6   �� *NewUserPassword+6�   �� 5%   
   -   5        $��
NameTBlock��5%   u   
������� J� IsHitTestVisible$ False��6+   $��0��6D   $��0��6Q   $��3��6a   $	��160��6�   $��25��6�   $��Bottom=�6�   Name6�   �� 5&   
   -   5        $��SurnameTBlock��5&   u   
�������$ False��6+   $��1��6D   $��0��6Q   $��3��6a   $	��160��6�   $��25��6�   $��Bottom=�6�   	Surname6�   �� 5'   
   -	   5        $��MidNameTBlock��5'   u   
�������$ False��6+   $��2��6D   $��0��6Q   $��3��6a   $	��160��6�   $��25��6�   $��Bottom=�6�   Middle Name6�   �� 5(   
   -
   5        $��PhoneTBlock��5(   u   
�������$ False��6+   $��3��6D   $��0��6Q   $��3��6a   $	��160��6�   $��25��6�   $��Bottom=�6�   Phone Number6�   �� 5)   
   -   5        $��LoginTBlock��5)   u   
�������$ False��6+   $��4��6D   $��0��6Q   $��3��6a   $	��160��6�   $��25��6�   $��Bottom=�6�   Login6�   �� 5*   
   -   5        $��
PassTBlock��5*   u   
�������$ False��6+   $��5��6D   $��0��6Q   $��3��6a   $	��160��6�   $��25��6�   $��Bottom=�6�   
Password6�   �� 5-   
   -   5        $��	SignUpBtn��5-   d   $��7��63   $��0��6@   $��2��6P   $��75��6u   $��25��6�   $
��Left=�6�   $��17 5 5 5q�6�    �� 	IsDefault$
 True��6�   ��6   �� *SignUpCommand+.��6�   	Sign Up6�   �� 5.   
   -   5        $��BackBtn��5.   B   $��7��6   $��1��6   $��3��6.   $��75��6Q   $��25��6\   $��Right=�6h   $��5 5 17 5q�6�    �� IsCancel$
 True��6�   .��6�   Back6�   5/      50      