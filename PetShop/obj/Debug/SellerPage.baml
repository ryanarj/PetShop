   M S B A M L   `   `   `  ����B  >PetShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PetShopPetShop  5          PetShop.SellerPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:PetShop     5        N� Title$  
SellerPage��5       N� 
Background
 �����$	��355��6-   $	��400��6:   .��5
      � $
��Left=�6   $	��300��6&   .+�5   
   �� -   5         ��Name$ addPet��5      $��Add Pet��66   $
��Left=�6H   $��
55,185,0,0q�6c   $	��Top=�6w   $��75��6�   $��45��6�   �� 5   
   -   5        $ 	removePet��5      $��Remove a pet��6<   $
��Left=�6S   $��
55,280,0,0q�6n   $	��Top=�6�   $��84��6�   $��45��6�   �� 5   
   -   5         ��Name$ label��5      $��Select the animal.��6   $
��Left=�6<   $��	34,15,0,0q�6W   $	��Top=�6j   $��46��6�   $	��105��6�   �� 5   
   -   5         ��Name$ petCB��5      $
��Left=�6"   $��	30,61,0,0q�6=   $	��Top=�6P   $	��120��6h   .@�5      �� -   5        $��cbiCat��5      .��6)   Cat6.   �� 5      -   5        $��cbiWolf��5      .��6*   Wolf60   �� 5      -   5        $��
cbiPanther��5      .��6-   	Panther66   �� 5      -   5        $��cbiPuppy��5      .��6+   Puppy62   5      �� 5   
   -	   5        $ 
label_Copy��5      $!��Update the price of Animal.��6$   $
��Left=�6J   $��	30,94,0,0q�6e   $	��Top=�6x   $��46��6�   �� 5   
   -
   5        $ UpdatePrice��5      $��Update Price��6@   $
��Left=�6W   $��
55,245,0,0q�6r   $	��Top=�6�   $��75��6�   �� 5   
   -   5         ��Name$ 
newPriceTB��5      $��23��6&   $��30,140,150,0q�62    �� TextWrapping$
 Wrap=�6H   $�� ��6\   $	��Top=�6d    J� RenderTransformOrigin$ -0.625,0.435&�6|   �� 5   
   -   5        $ 	addSupply��5      $��
Add Supply��6<   $
��Left=�6Q   $��235,185,-10,0q�6l   $	��Top=�6�   $��75��6�   $��45��6�   �� 5   
   -   5        $ removeSupply��5      $��Remove Supply��6B   $
��Left=�6Z   $��235,280,-19,0q�6u   $	��Top=�6�   $��84��6�   $��45��6�   �� 5   
   -   5        $ label_Copy1��5      $��Select the Supply.��6%   $
��Left=�6B   $��214,15,-19,0q�6]   $	��Top=�6s   $��46��6�   $	��105��6�   �� 5   
   -   5        $ petSupplyCB��5      $
��Left=�6(   $��210,61,-30,0q�6C   $	��Top=�6Y   $	��120��6q   .@�5      �� -   5         ��Name$ cbiCatSupply��5      $��CatFood��61   �� 5      -   5        $ cbiPantherSupply��5      $��PantherFood��65   �� 5      -   5        $ cbiWolfSupply��5      $��WolfFood��62   �� 5      -   5        $ cbiPuppySupply��5      $��	PuppyFood��63   5       �� 5!   
   -   5        $ label_Copy2��5!      $%��Update the price of the Supply.��6%   $
��Left=�6O   $��210,94,-95,0q�6j   $	��Top=�6�   $��46��6�   $	��185��6�   �� 5"   
   -   5        $ UpdateSupplyBtn��5"      $��Update Supply Price��6H   $
��Left=�6f   $��205,235,-30,0q�6�   $	��Top=�6�   $	��125��6�   $��30��6�   �� 5#   
   -   5        $ newSupplyPrintTB��5#      $��23��6,   $��210,140,-30,0q�68   $
 Wrap=�6O   $�� ��6c   $	��Top=�6k   $ -0.625,0.435&�6�   5$      5%      