/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/*
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ImageURL], [NutrtionLabel], [Description], [Price], [Ingredient], [Quantity]) VALUES (1, N'Banana', N'https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.walmart.com%2Fip%2FFresh-Bananas-per-pound%2F44390948&psig=AOvVaw3U-89YZRbTO_xIpd_oh3Uy&ust=1679878318939000&source=images&cd=vfe&ved=0CAwQjRxqFwoTCIi7rcWw-P0CFQAAAAAdAAAAABAE', N'https://cdn.shopify.com/s/files/1/0336/7167/5948/products/image-of-organic-bananas-organics-27999845154860_327x569.jpg?v=1626729677', N'Banana', CAST(1 AS Decimal(18, 0)), N'Banana', 1)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ImageURL], [NutrtionLabel], [Description], [Price], [Ingredient], [Quantity]) VALUES (2, N'Banana', N'https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Banana.png/800px-Banana.png', N'https://cdn.shopify.com/s/files/1/0336/7167/5948/products/image-of-organic-bananas-organics-27999845154860_327x569.jpg?v=1626729677', N'Banana', CAST(1 AS Decimal(18, 0)), N'Banana', 1)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ImageURL], [NutrtionLabel], [Description], [Price], [Ingredient], [Quantity]) VALUES (1002, N'DefaultTest', N'URL', N'NutritionURL', N'Description', CAST(1 AS Decimal(18, 0)), N'Ingredient(s)', 0)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ImageURL], [NutrtionLabel], [Description], [Price], [Ingredient], [Quantity]) VALUES (2002, N'Banana', N'https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.walmart.com%2Fip%2FFresh-Bananas-per-pound%2F44390948&psig=AOvVaw3U-89YZRbTO_xIpd_oh3Uy&ust=1679878318939000&source=images&cd=vfe&ved=0CAwQjRxqFwoTCIi7rcWw-P0CFQAAAAAdAAAAABAE', N'https://cdn.shopify.com/s/files/1/0336/7167/5948/products/image-of-organic-bananas-organics-27999845154860_327x569.jpg?v=1626729677', N'aasdfa', CAST(0 AS Decimal(18, 0)), N'dcat', 0)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ImageURL], [NutrtionLabel], [Description], [Price], [Ingredient], [Quantity]) VALUES (2003, N'Banana', N'asdfasdf', N'https://cdn.shopify.com/s/files/1/0336/7167/5948/products/image-of-organic-bananas-organics-27999845154860_327x569.jpg?v=1626729677', N'asdfasdf', CAST(1 AS Decimal(18, 0)), N'asdfasfd', 0)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO

*/