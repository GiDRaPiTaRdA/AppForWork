   M S B A M L   `   `   `  ���� F  BAppForWork2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:AppForWork2.ConvertersAppForWork2.Converters  !    AppForWork2.View.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Ninteractivity:http://schemas.microsoft.com/expression/2010/interactivity  4	viewModel$clr-namespace:AppForWork2.Converters  -     � Title$  
MainWindow��$	��350��$	��525��$	��350��$	��525��
������� � 	Resources 6   0AppForWork2.Converters.BoolToVisibilityConverter   BoolToVisibilityConverter=   7AppForWork2.Converters.BoolToInverseVisibilityConverter $  BoolToInverseVisibilityConverter)   #AppForWork2.Converters.BoolInvertor  BoolInvertor  
ThemeColor  
ThemeBrush �� Color  VehicleItem �� CornerRadius � ColumnDefinitions � RowDefinitions �� Path �� 	Converter �� ElementName  PartItem	 �� Mode
 �� UpdateSourceTrigger �� 
IsReadOnly  	AddOnItem �� 
TargetType d�Name d� 	IsChecked �� Triggers P� 
SourceName P� Property P� Value �� Property �� Value��%�  &	        &	      &	 
     &	      &	 #     &	 /     7  7  &	 �    &	 .    7        ��
Aquamarine���� # �  �� .R��� $��qwerty��$��5q�$��1q�
���   �
�������$ 4��._�� $��5q�$��Stretch=�$��Center=� �� $	��10* ��� $��4* �.+�� $��3q�$��0�� �� �� .+��� $��0��$��12(�$��Italic$�$��Segoe UI Black)����� $
 Name�� $��1��$
��Left=� �� �� .+��� $��0��$��12(����� $
 Type��� $��1��$��20(�$��Center=�$��*��
��� E��$��Stencil)�y��� $ IsItemSaved�8   �� $��1��8�� $��R��$��30��$��30��$��Segoe UI Black)�$��15(����� $&  DataContext.RepareVehicleCommand�$ 
LayoutRoot��{��� $ IsItemSaved����� �� .R��� $��1q�$��1q�
���   �$ 4��$��25��#���  ._�� $��Stretch=�$��1q�$��Center=� �� $��5* ��� $��1* ��� $��3* ��� $
��0.1* �.+��� $��0��$��Italic$����� $
 Type�� $��2��$��Right=� �� $��1* �.+��� ���� $ State�$	 TwoWay=�$
 PropertyChanged=� �� $- 'DataContext.SelectedVehicle.IsItemSaved�$ 
LayoutRoot��.���� .R��� ���� " ��.R�d� $ toggleButton��$��1q�$��Stretch=�#���  ���� $
 Name� �� $ NeedsRepare�$	 TwoWay=�{��� $- 'DataContext.SelectedVehicle.IsItemSaved�$ 
LayoutRoot��8    P� $ toggleButton�� �@d�	IsChecked$
 TrueY�. ���  � ��$
 True��P�  � ��$
 True��. ���  �@d�	IsChecked$
 TrueY�.��� -   $��
LayoutRoot�� � DataContext �� .+��  �� $��5 ��� $��30 ��� $��5 ��� $	��10* ��� $��5 �.+�� $��1�� �� $��5 ��� $	��165 ��� $��5 ��� $��2* ��� $��5 ��� $	��100 ��� $��5 �.+��� $��Stretch=�$��15(�$��1������ $ EVehicleTypes� �� SelectedItem �� $ VehicleType��� $��15(� �� MaxLines$ 1�� �� 	MaxLength$ 20��$��3��$��Segoe UI Black)����� $ VehicleName�$
 PropertyChanged=�{��� $! SelectedVehicle.IsItemSaved�# [ �� $��Create��$��15(�$��5������ $ NewVehicleCommand�� $��3�� �� $��5 ��� $��1* ��� $��5 ��� $��2* ��� $��5 �.+��� $��1��$��Stretch=�#��[ ���� $ CarStation.Vehicles� �� $ SelectedVehicle�$	 TwoWay=�� $��3�� �� $��1* ��� $��5 ��� $	��100 �.+�� $��0�� �� $��5* ��� $��5 ��� $��30 �.+��� $��0��$��Stretch=�#��[ ���� $&  SelectedVehicle.VehiclePartsList�� $��2��
���iii� �� $��3* ��� $��1* �.+��� $��0��$��Italic$�$��20(�
������� �� TextAlignment$ Center=�$��Amount to pay : ���� $��1��$��Italic$�$��22(�
�������$ Center=����� $ AmountToPay�� $��2�� �� $��5 ��� $	��10* ��� $��80 ��� $��5 ��� $��30 ��� $��5 ��� $��30 ��� $��5 ��� $��30 ��� $��5 ��� $��30 �.+�� $��2��.+��� $��1q�
���   �
�������$��Bottom=�$��1q�._��  �� $��20 ��� $��1* �.+��� $��0��$��Options��$��1q��� $��1��$��0q�$��Stretch=�#��[ ���� $&  SelectedVehicle.AddOnsCollection��� $��4��$��Remove Current������ $" RemoveSelectedVehicleCommand��� $��6��$��
Remove All������ $ DellAllFromXMLCommand��� $��8��$
��Save������ *SaveVehicleCommand+ �� NotifyOnSourceUpdated . 