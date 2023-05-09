USE [EcommDB]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'5fecd853-22b5-43fb-801a-6cafed595e9f', N'Cusotmer', N'CUSOTMER', N'e08c62ad-c446-473b-b690-3eaa7c9a2285')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'a2e95dbe-39d9-4bc8-9fac-f3e89d5f5c38', N'Manager', N'MANAGER', N'cd3afaae-ac0f-47ee-8232-0eedff9c5725')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'c677f8fd-1d99-4a8b-84ea-be1724f2d6a9', N'Front Desk', N'FRONT DESK', N'f71fb305-157c-4b29-b633-9063cd229d91')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'fb3500d5-db6b-4dfb-b615-29b26faf9c3b', N'Kitchen', N'KITCHEN', N'3242e430-a3d7-4839-b8e1-9316f75779d0')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [City], [Discriminator], [Name], [PostalCode], [StreetAddress], [state]) VALUES (N'82e986fa-82ce-499e-a454-67a8ca9fe220', N'mohammad.suliaman@gmail.com', N'MOHAMMAD.SULIAMAN@GMAIL.COM', N'mohammad.suliaman@gmail.com', N'MOHAMMAD.SULIAMAN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEFswW72XczIursEfYuYFJSyfc/JXc1vrSdglv5BrlJ0v9HizJszNCjZYGIhr0159vQ==', N'H2KTB2ULPG7LCKCZQVAG4ZFOH2DYWHZU', N'70cf0c6a-825e-457c-8bdb-f04c3b8dfff8', N'+1 (657) 154-1192', 0, 0, NULL, 1, 0, N'Doloremque nihil bea', N'ApplicationUser', N'Leila Butler', N'Sed irure laborum co', N'Est qui dolorum sed', N'Ea voluptates pariat')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [City], [Discriminator], [Name], [PostalCode], [StreetAddress], [state]) VALUES (N'be64d23c-1e2a-44c6-88d0-f330a3a34f30', N'admin@gmail.com', N'ADMIN@GMAIL.COM', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEBdhYdZDcbDqKj1g3dMGYKWOS0a40sA4zDD+lFPS6RHyVC+q3fs5Jy+lGdWk1PCL/w==', N'V2SIWG4EWXFYVOUO72WRXJJERIL46346', N'c072b239-7627-49f5-8083-297e3c296cef', N'+1 (924) 765-6186', 0, 0, NULL, 1, 0, N'Eu quis aut qui et', N'ApplicationUser', N'Kennan Bond', N'In illo cupiditate s', N'Labore anim ullam te', N'Sed necessitatibus e')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [City], [Discriminator], [Name], [PostalCode], [StreetAddress], [state]) VALUES (N'd49d2155-5f85-4cda-a476-5d9d96629245', N'cust@gmail.com', N'CUST@GMAIL.COM', N'cust@gmail.com', N'CUST@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEKOEh1UFgNCF8Tmiop2jLodTFalLpXLmg1tfNY+wprsb3xYGEZdU8rVUr1InHm8iaA==', N'NOHR377ISOPFQK23X3FDYZIPEP6YF7QL', N'1cf29236-4dab-40cd-9fd3-14c3c5382f21', N'+1 (137) 288-9342', 0, 0, NULL, 1, 0, N'Doloribus tempore a', N'ApplicationUser', N'Rhona Forbes', N'Reprehenderit enim ', N'Molestiae qui blandi', N'Qui quisquam commodo')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [City], [Discriminator], [Name], [PostalCode], [StreetAddress], [state]) VALUES (N'fdd32f42-b562-4532-b7fe-18eddd9b3da7', N'admin2@gmail.com', N'ADMIN2@GMAIL.COM', N'admin2@gmail.com', N'ADMIN2@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEAF/gkFsaB22tWBswnHJoZTn8Ibqfb3smyBMH6oTAHci7lOhCbNsZM7AqU0+hGC/Eg==', N'OSPCQMTCZGQ6E66MEU77VQ3VXPXXGS5N', N'17eb038b-aafc-4469-9ca6-257df5b60a6d', N'+1 (268) 597-4055', 0, 0, NULL, 1, 0, N'Eum consequatur Qui', N'ApplicationUser', N'Belle Holcomb', N'Consequatur unde eni', N'Veniam autem odit e', N'Praesentium velit l')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'82e986fa-82ce-499e-a454-67a8ca9fe220', N'5fecd853-22b5-43fb-801a-6cafed595e9f')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd49d2155-5f85-4cda-a476-5d9d96629245', N'5fecd853-22b5-43fb-801a-6cafed595e9f')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'be64d23c-1e2a-44c6-88d0-f330a3a34f30', N'a2e95dbe-39d9-4bc8-9fac-f3e89d5f5c38')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fdd32f42-b562-4532-b7fe-18eddd9b3da7', N'a2e95dbe-39d9-4bc8-9fac-f3e89d5f5c38')
GO
SET IDENTITY_INSERT [dbo].[OrderHeaders] ON 

INSERT [dbo].[OrderHeaders] ([id], [UserId], [OrderDate], [OrderTotalOrginal], [OrderTotal], [PickUpTime], [Status], [PaymentStatus], [Comments], [PickUpName], [PhoneNumber], [TransactionId]) VALUES (12, N'be64d23c-1e2a-44c6-88d0-f330a3a34f30', CAST(N'2023-03-26T00:54:54.9390292' AS DateTime2), 2381, 2366, CAST(N'2023-03-26T11:00:00.0000000' AS DateTime2), N'Pending', N'Pending', N'cc', N'Kennan Bond', N'+1 (924) 765-6186', NULL)
INSERT [dbo].[OrderHeaders] ([id], [UserId], [OrderDate], [OrderTotalOrginal], [OrderTotal], [PickUpTime], [Status], [PaymentStatus], [Comments], [PickUpName], [PhoneNumber], [TransactionId]) VALUES (13, N'be64d23c-1e2a-44c6-88d0-f330a3a34f30', CAST(N'2023-03-26T00:57:21.4639376' AS DateTime2), 10552, 10537, CAST(N'2023-03-26T16:00:00.0000000' AS DateTime2), N'Pending', N'Pending', N'xx', N'Kennan Bond', N'+1 (924) 765-6186', NULL)
INSERT [dbo].[OrderHeaders] ([id], [UserId], [OrderDate], [OrderTotalOrginal], [OrderTotal], [PickUpTime], [Status], [PaymentStatus], [Comments], [PickUpName], [PhoneNumber], [TransactionId]) VALUES (14, N'be64d23c-1e2a-44c6-88d0-f330a3a34f30', CAST(N'2023-04-08T01:46:39.5755128' AS DateTime2), 609, 609, CAST(N'2023-04-15T16:00:00.0000000' AS DateTime2), N'Pending', N'Pending', NULL, N'Kennan Bond', N'+1 (924) 765-6186', NULL)
INSERT [dbo].[OrderHeaders] ([id], [UserId], [OrderDate], [OrderTotalOrginal], [OrderTotal], [PickUpTime], [Status], [PaymentStatus], [Comments], [PickUpName], [PhoneNumber], [TransactionId]) VALUES (15, N'be64d23c-1e2a-44c6-88d0-f330a3a34f30', CAST(N'2023-04-24T16:42:59.0154594' AS DateTime2), 609, 594, CAST(N'2023-04-24T18:00:00.0000000' AS DateTime2), N'Pending', N'Pending', N'balllallalal', N'Kennan Bond', N'+1 (924) 765-6186', NULL)
INSERT [dbo].[OrderHeaders] ([id], [UserId], [OrderDate], [OrderTotalOrginal], [OrderTotal], [PickUpTime], [Status], [PaymentStatus], [Comments], [PickUpName], [PhoneNumber], [TransactionId]) VALUES (1012, N'be64d23c-1e2a-44c6-88d0-f330a3a34f30', CAST(N'2023-05-08T19:44:48.6075918' AS DateTime2), 34.5, 34.5, CAST(N'2023-05-09T11:00:00.0000000' AS DateTime2), N'Pending', N'Pending', NULL, N'Kennan Bond', N'+1 (924) 765-6186', NULL)
INSERT [dbo].[OrderHeaders] ([id], [UserId], [OrderDate], [OrderTotalOrginal], [OrderTotal], [PickUpTime], [Status], [PaymentStatus], [Comments], [PickUpName], [PhoneNumber], [TransactionId]) VALUES (1015, N'82e986fa-82ce-499e-a454-67a8ca9fe220', CAST(N'2023-05-08T21:01:50.5001846' AS DateTime2), 76.5, 76.5, CAST(N'2023-05-09T11:00:00.0000000' AS DateTime2), N'Pending', N'Pending', NULL, N'Leila Butler', N'+1 (657) 154-1192', NULL)
INSERT [dbo].[OrderHeaders] ([id], [UserId], [OrderDate], [OrderTotalOrginal], [OrderTotal], [PickUpTime], [Status], [PaymentStatus], [Comments], [PickUpName], [PhoneNumber], [TransactionId]) VALUES (1016, N'fdd32f42-b562-4532-b7fe-18eddd9b3da7', CAST(N'2023-05-09T09:06:39.6680813' AS DateTime2), 10.5, 10.5, CAST(N'2023-05-09T12:00:00.0000000' AS DateTime2), N'Pending', N'Pending', NULL, N'Belle Holcomb', N'+1 (268) 597-4055', NULL)
INSERT [dbo].[OrderHeaders] ([id], [UserId], [OrderDate], [OrderTotalOrginal], [OrderTotal], [PickUpTime], [Status], [PaymentStatus], [Comments], [PickUpName], [PhoneNumber], [TransactionId]) VALUES (1017, N'fdd32f42-b562-4532-b7fe-18eddd9b3da7', CAST(N'2023-05-09T09:11:48.7707875' AS DateTime2), 7, 7, CAST(N'2023-05-09T12:00:00.0000000' AS DateTime2), N'Pending', N'Pending', NULL, N'Belle Holcomb', N'+1 (268) 597-4055', NULL)
INSERT [dbo].[OrderHeaders] ([id], [UserId], [OrderDate], [OrderTotalOrginal], [OrderTotal], [PickUpTime], [Status], [PaymentStatus], [Comments], [PickUpName], [PhoneNumber], [TransactionId]) VALUES (1018, N'fdd32f42-b562-4532-b7fe-18eddd9b3da7', CAST(N'2023-05-09T09:14:00.8551484' AS DateTime2), 32.5, 32.5, CAST(N'2023-05-09T12:00:00.0000000' AS DateTime2), N'Pending', N'Pending', NULL, N'Belle Holcomb', N'+1 (268) 597-4055', NULL)
SET IDENTITY_INSERT [dbo].[OrderHeaders] OFF
GO
SET IDENTITY_INSERT [dbo].[Cateogries] ON 

INSERT [dbo].[Cateogries] ([Id], [Name]) VALUES (1, N'Drinks')
INSERT [dbo].[Cateogries] ([Id], [Name]) VALUES (2, N'Meats')
INSERT [dbo].[Cateogries] ([Id], [Name]) VALUES (3, N'Dairy')
INSERT [dbo].[Cateogries] ([Id], [Name]) VALUES (4, N'Fruits')
SET IDENTITY_INSERT [dbo].[Cateogries] OFF
GO
SET IDENTITY_INSERT [dbo].[SubCateogries] ON 

INSERT [dbo].[SubCateogries] ([Id], [Name], [CategoryId]) VALUES (1, N'Coca Cola', 1)
INSERT [dbo].[SubCateogries] ([Id], [Name], [CategoryId]) VALUES (3, N'Fish', 2)
INSERT [dbo].[SubCateogries] ([Id], [Name], [CategoryId]) VALUES (4, N'Beef', 2)
INSERT [dbo].[SubCateogries] ([Id], [Name], [CategoryId]) VALUES (5, N'Chicken', 2)
INSERT [dbo].[SubCateogries] ([Id], [Name], [CategoryId]) VALUES (6, N'Milk', 3)
INSERT [dbo].[SubCateogries] ([Id], [Name], [CategoryId]) VALUES (7, N'Yogurt', 1)
INSERT [dbo].[SubCateogries] ([Id], [Name], [CategoryId]) VALUES (8, N'Cheese', 3)
INSERT [dbo].[SubCateogries] ([Id], [Name], [CategoryId]) VALUES (9, N'Apple', 4)
INSERT [dbo].[SubCateogries] ([Id], [Name], [CategoryId]) VALUES (10, N'Banana', 4)
INSERT [dbo].[SubCateogries] ([Id], [Name], [CategoryId]) VALUES (11, N'Strawberry', 4)
SET IDENTITY_INSERT [dbo].[SubCateogries] OFF
GO
SET IDENTITY_INSERT [dbo].[MenuItems] ON 

INSERT [dbo].[MenuItems] ([Id], [Name], [Description], [Price], [Image], [CategoryId], [SubCategoryId]) VALUES (1, N'Fish', N'Fish and fish products are consumed as food all over the world. With other seafoods, they provides the world''s prime source of high-quality protein; 14&ndash;16 percent of the animal protein consumed worldwide. Over one billion people rely on fish as their primary source of animal protein. Its price is per kilo', 22, N'\images\133278423772749715.jpg', 2, 3)
INSERT [dbo].[MenuItems] ([Id], [Name], [Description], [Price], [Image], [CategoryId], [SubCategoryId]) VALUES (2, N'Coca Cola -2 liter', N'Coca-Cola, or Coke, is a carbonated soft drink manufactured by the Coca-Cola Company. In 2013, Coke products were sold in over 200 countries worldwide, with consumers drinking more than 1.8 billion company beverage servings each day. Coca-Cola ranked No. 87 in the 2018 Fortune 500 list of the largest United States corporations by total revenue. Based on Interbrand''s "best global brand" study of 2020,&nbsp;', 3.5, N'\images\133278424152502325.webp', 1, 1)
INSERT [dbo].[MenuItems] ([Id], [Name], [Description], [Price], [Image], [CategoryId], [SubCategoryId]) VALUES (3, N'Diet Coca Cola', N'Diet Coke (also branded as Coca-Cola Light, Coca-Cola Diet or Coca-Cola Light Taste) is a sugar-free and low-calorie soft drink produced and distributed by the Coca-Cola Company. It contains artificial sweeteners instead of sugar. Unveiled on July 8, 1982, and introduced in the United States on August 9, 1982, it was the first new brand since 1886 to use the Coca-Cola trademark. The product quickly overtook the company''s existing diet cola, Tab (which was discontinued in 2022), in sales.', 2, N'\images\133278424627822458.jpg', 1, 1)
INSERT [dbo].[MenuItems] ([Id], [Name], [Description], [Price], [Image], [CategoryId], [SubCategoryId]) VALUES (4, N'Chicken', N'From Wikipedia, the free encyclopedia Chicken Chickens in market.jpg Whole chickens for sale in a public market Course Starter, main meal, side dish Serving temperature&nbsp;Hot and cold Media: Chicken, broiler, meat and skin, cooked, stewed Nutritional value per 100 g (3.5 oz) Energy 916 kJ (219 kcal) Carbohydrates 0.00 g Fat 12.56 g Saturated 3.500 g Monounsaturated 4.930 g Polyunsaturated 2.740 g Protein 24.68 g Tryptophan 0.276 g Threonine 1.020 g Isoleucine 1.233 g Leucine 1.797 g Lysine 2.011 g Methionine 0.657 g Cystine&nbsp;0.329 g Phenylalanine&nbsp;0.959 g Tyrosine 0.796 g Valine 1.199 g Arginine 1.545 g Histidine 0.726 g Alanine 1.436 g Aspartic acid 2.200 g Glutamic acid 3.610 g Glycine 1.583 g Proline 1.190 g Serine 0.870 g Vitamins&nbsp;Chicken can be prepared in a vast range of ways, including baking, grilling, barbecuing, frying, and boiling. Since the latter half of the 20th century, prepared chicken has become a staple of fast food.', 17, N'\images\133278425489340522.jpg', 2, 3)
INSERT [dbo].[MenuItems] ([Id], [Name], [Description], [Price], [Image], [CategoryId], [SubCategoryId]) VALUES (5, N'Beef Strips', N'beef, flesh of mature cattle, as distinguished from veal, the flesh of calves. The best beef is obtained from early maturing, special beef breeds. High-quality beef has firm, velvety, fine-grained lean, bright red in color and well-marbled. The fat is smooth, creamy white, and well distributed.', 21.5, N'\images\133278425841707960.jpg', 2, 4)
INSERT [dbo].[MenuItems] ([Id], [Name], [Description], [Price], [Image], [CategoryId], [SubCategoryId]) VALUES (6, N'Milk', N'Dairy Products The most common animal milks, water buffaloes, breeder goats and ewes, are found here. Its price is per liter', 2, N'\images\133278427467042542.jfif', 3, 6)
INSERT [dbo].[MenuItems] ([Id], [Name], [Description], [Price], [Image], [CategoryId], [SubCategoryId]) VALUES (7, N'Apple', NULL, 7, N'\images\133278427852843257.jpg', 4, 9)
INSERT [dbo].[MenuItems] ([Id], [Name], [Description], [Price], [Image], [CategoryId], [SubCategoryId]) VALUES (8, N'Banana', NULL, 8, N'\images\133278428105418237.jpg', 4, 10)
SET IDENTITY_INSERT [dbo].[MenuItems] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([id], [OrderId], [MenuItemId], [Count], [Name], [Price], [Description]) VALUES (15, 12, 2, 3, N'Casey Joyner', 609, N'<p>cvbgfhfghfgh</p>')
INSERT [dbo].[OrderDetails] ([id], [OrderId], [MenuItemId], [Count], [Name], [Price], [Description]) VALUES (16, 12, 3, 1, N'Rogan Dunlap', 554, N'<p>gfhfg</p>')
INSERT [dbo].[OrderDetails] ([id], [OrderId], [MenuItemId], [Count], [Name], [Price], [Description]) VALUES (17, 13, 2, 1, N'Casey Joyner', 609, N'<p>cvbgfhfghfgh</p>')
INSERT [dbo].[OrderDetails] ([id], [OrderId], [MenuItemId], [Count], [Name], [Price], [Description]) VALUES (18, 13, 3, 14, N'Rogan Dunlap', 554, N'<p>gfhfg</p>')
INSERT [dbo].[OrderDetails] ([id], [OrderId], [MenuItemId], [Count], [Name], [Price], [Description]) VALUES (19, 13, 1, 3, N'Boris Wade', 729, N'<p>dfgdf gdf dgdfgdfgdgddd fdgdgdddgdg dgfgdff</p>')
INSERT [dbo].[OrderDetails] ([id], [OrderId], [MenuItemId], [Count], [Name], [Price], [Description]) VALUES (20, 14, 2, 1, N'Casey Joyner', 609, N'<p>cvbgfhfghfgh</p>')
INSERT [dbo].[OrderDetails] ([id], [OrderId], [MenuItemId], [Count], [Name], [Price], [Description]) VALUES (21, 15, 2, 1, N'Casey Joyner', 609, N'<p>cvbgfhfghfgh</p>')
INSERT [dbo].[OrderDetails] ([id], [OrderId], [MenuItemId], [Count], [Name], [Price], [Description]) VALUES (1015, 1012, 2, 5, N'Coca Cola -2 liter', 3.5, N'Coca-Cola, or Coke, is a carbonated soft drink manufactured by the Coca-Cola Company. In 2013, Coke products were sold in over 200 countries worldwide, with consumers drinking more than 1.8 billion company beverage servings each day. Coca-Cola ranked No. 87 in the 2018 Fortune 500 list of the largest United States corporations by total revenue. Based on Interbrand''s "best global brand" study of 2020,&nbsp;')
INSERT [dbo].[OrderDetails] ([id], [OrderId], [MenuItemId], [Count], [Name], [Price], [Description]) VALUES (1016, 1012, 4, 1, N'Chicken', 17, N'From Wikipedia, the free encyclopedia Chicken Chickens in market.jpg Whole chickens for sale in a public market Course Starter, main meal, side dish Serving temperature&nbsp;Hot and cold Media: Chicken, broiler, meat and skin, cooked, stewed Nutritional value per 100 g (3.5 oz) Energy 916 kJ (219 kcal) Carbohydrates 0.00 g Fat 12.56 g Saturated 3.500 g Monounsaturated 4.930 g Polyunsaturated 2.740 g Protein 24.68 g Tryptophan 0.276 g Threonine 1.020 g Isoleucine 1.233 g Leucine 1.797 g Lysine 2.011 g Methionine 0.657 g Cystine&nbsp;0.329 g Phenylalanine&nbsp;0.959 g Tyrosine 0.796 g Valine 1.199 g Arginine 1.545 g Histidine 0.726 g Alanine 1.436 g Aspartic acid 2.200 g Glutamic acid 3.610 g Glycine 1.583 g Proline 1.190 g Serine 0.870 g Vitamins&nbsp;Chicken can be prepared in a vast range of ways, including baking, grilling, barbecuing, frying, and boiling. Since the latter half of the 20th century, prepared chicken has become a staple of fast food.')
INSERT [dbo].[OrderDetails] ([id], [OrderId], [MenuItemId], [Count], [Name], [Price], [Description]) VALUES (1019, 1015, 1, 3, N'Fish', 22, N'Fish and fish products are consumed as food all over the world. With other seafoods, they provides the world''s prime source of high-quality protein; 14&ndash;16 percent of the animal protein consumed worldwide. Over one billion people rely on fish as their primary source of animal protein. Its price is per kilo')
INSERT [dbo].[OrderDetails] ([id], [OrderId], [MenuItemId], [Count], [Name], [Price], [Description]) VALUES (1020, 1015, 2, 3, N'Coca Cola -2 liter', 3.5, N'Coca-Cola, or Coke, is a carbonated soft drink manufactured by the Coca-Cola Company. In 2013, Coke products were sold in over 200 countries worldwide, with consumers drinking more than 1.8 billion company beverage servings each day. Coca-Cola ranked No. 87 in the 2018 Fortune 500 list of the largest United States corporations by total revenue. Based on Interbrand''s "best global brand" study of 2020,&nbsp;')
INSERT [dbo].[OrderDetails] ([id], [OrderId], [MenuItemId], [Count], [Name], [Price], [Description]) VALUES (1021, 1016, 2, 3, N'Coca Cola -2 liter', 3.5, N'Coca-Cola, or Coke, is a carbonated soft drink manufactured by the Coca-Cola Company. In 2013, Coke products were sold in over 200 countries worldwide, with consumers drinking more than 1.8 billion company beverage servings each day. Coca-Cola ranked No. 87 in the 2018 Fortune 500 list of the largest United States corporations by total revenue. Based on Interbrand''s "best global brand" study of 2020,&nbsp;')
INSERT [dbo].[OrderDetails] ([id], [OrderId], [MenuItemId], [Count], [Name], [Price], [Description]) VALUES (1022, 1017, 2, 2, N'Coca Cola -2 liter', 3.5, N'Coca-Cola, or Coke, is a carbonated soft drink manufactured by the Coca-Cola Company. In 2013, Coke products were sold in over 200 countries worldwide, with consumers drinking more than 1.8 billion company beverage servings each day. Coca-Cola ranked No. 87 in the 2018 Fortune 500 list of the largest United States corporations by total revenue. Based on Interbrand''s "best global brand" study of 2020,&nbsp;')
INSERT [dbo].[OrderDetails] ([id], [OrderId], [MenuItemId], [Count], [Name], [Price], [Description]) VALUES (1023, 1018, 2, 3, N'Coca Cola -2 liter', 3.5, N'Coca-Cola, or Coke, is a carbonated soft drink manufactured by the Coca-Cola Company. In 2013, Coke products were sold in over 200 countries worldwide, with consumers drinking more than 1.8 billion company beverage servings each day. Coca-Cola ranked No. 87 in the 2018 Fortune 500 list of the largest United States corporations by total revenue. Based on Interbrand''s "best global brand" study of 2020,&nbsp;')
INSERT [dbo].[OrderDetails] ([id], [OrderId], [MenuItemId], [Count], [Name], [Price], [Description]) VALUES (1024, 1018, 1, 1, N'Fish', 22, N'Fish and fish products are consumed as food all over the world. With other seafoods, they provides the world''s prime source of high-quality protein; 14&ndash;16 percent of the animal protein consumed worldwide. Over one billion people rely on fish as their primary source of animal protein. Its price is per kilo')
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220608112316_AddCatrgoryToDB', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220608165024_initial', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220609093541_AddSubCategoryToDB', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220609103245_AddSubCategoryToDB2', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220623093648_addmenuItem', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220629053755_addCoupontoDB', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220703095457_AddApplicationUsertoDB', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220703104724_AddApplicationUsertoDB2', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220728074709_AddShoopingCartToDB', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220801054614_addOrderAndDetailsToDB', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230213202456_kkk', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230305121329_changeTypeCouponDiscount', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230505130956_fff', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230506101416_RR', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230509060549_adlas', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230509061236_remCob', N'5.0.17')
GO
