   M S B A M L   `   `   `  ����?  ;avta, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:avtaavta  5   	       
avta.Admin   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:avta     5   	     � Title$  Admin��5   	   $	��450��6   $	��800��6$   .��5	      � $��20q�6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��0,0,0,10q�6,   .+�5      �� $E��?Статистика загруженности номеров:��6   $��16(�6A   $
��Bold"�6O   $��0,0,0,5q�6a   �� 5      -   5        $��OccupancyPercentageText��5      $��Загрузка: 0%��67   $��14(�6K   $��0,0,0,10q�6Y   �� 5      -   5        $��Обновить��5      $	��100��6C   $��30��6O   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ Users��5         AutoGenerateColumns$ False��5         CanUserAddRows$ False��5         
IsReadOnly$ False��5      $��
0,104,0,10q�5         SelectionMode$ Single=�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Логин��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto 6Q   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 64   �� *
Username+6Q     5      $ Роль��6%   $
	 Auto 6L   
 63   �� *Role+6L     5      $ Заблокирован��6%   $
	 Auto 6X   
 6;   �� *
IsLocked+6X     5      $! Последний вход��6%   $
	 Auto 6_   
 6=   �� *LastLoginDate+6_   5      �� 5   
   $ 
Horizontal=�6   $��Center=�6.   $��Bottom=�6K   $��0,0,0,20q�6f   .+�5      �� -   5        $/��)Добавить пользователя��5      $	��160��5      $��30��5       ���#BFAA98���#444$
��Bold"�5#      6'   �� 5$      -   5        $"��Разблокировать��5$      $	��160��5%      $��30��5&      ���#BFAA98���#444$
��Bold"�5)      $��5q�5*      6    �� 5+      -   5        $+��%Сохранить изменения��5+      $	��160��5,      $��30��5-      ���#BFAA98���#444$
��Bold"�50      $��5q�51      6    53      54      55      