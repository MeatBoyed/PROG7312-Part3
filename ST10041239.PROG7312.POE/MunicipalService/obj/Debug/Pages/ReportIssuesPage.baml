   M S B A M L   `   `   `  ����K  GMunicipalService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MunicipalService.PagesMunicipalService.Pages  5      -    'MunicipalService.Pages.ReportIssuesPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:MunicipalService.Pages     5        N� Title$  ReportIssuesPage��5
      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Report an Issue��6   $��24(�6+   $��2��69   $��0,0,0,20q�6M   �� 5   
   $��	Location:��6   $��1��6%   $��Center=�62   �� 5   
   -   5         ��Name$ LocationTextBox��5      $��1��6+   $��1��68   $��5q�6H   6S   �� 5!   
   $��	Category:��6   $��2��6%   $��Center=�62   �� 5"   
   -   5         ��Name$ CategoryComboBox��5"      $��2��6-   $��1��6:   $��5q�6J   .@�5#      �� $��
Sanitation��6   �� 5$      $��Roads��6   �� 5%      $��	Utilities��6   �� 5&      $��Other��6   5'      �� 5)   
   $��Description:��6   $��3��6(   $	��Top=�65   $��0,5,0,0q�6M   �� 5*   
   -   5         ��Name$ DescriptionRichTextBox��5*      $��3��66   $��1��6C   $��5q�6S   $	��100��6^    �� AcceptsReturn . 6�   �� 5,   
   -   5        $��Attach Media��5,      $��4��6(   $��1��65   $
��Left=�6E   $��5q�6`   $
��10,5q�6k   6z   �� 5.   
   -   5         ��Name$ AttachmentNameTextBlock��5.      $��5��65   $��1��6B   $��5q�6R   � 50   
   -   5         �Name$ ProgressBar��50      $��6��6+   $��2��68   $��20��6L   $
��0,10q�6X   �� 52   
   $��7��6   $��2��6"   	 �� Orientation$	 
Horizontal=�66   $��Right=�6O   .+�53      �� -   5        $��Submit��53      $	��100��6&   $��5q�62   6=   �� 54      -   5        $��View Your Reported Issues��54      $	��120��69   $��5q�6E   6P   55      56      57      