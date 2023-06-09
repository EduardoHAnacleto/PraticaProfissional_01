USE [PraticaProfissional1]
GO
/****** Object:  Table [dbo].[BILLSINSTALMENTS]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BILLSINSTALMENTS](
	[paycondition_id] [int] NOT NULL,
	[instalment_number] [int] NOT NULL,
	[paymethod_id] [int] NOT NULL,
	[total_days] [int] NOT NULL,
	[value_percentage] [decimal](5, 2) NULL,
	[date_creation] [datetime] NOT NULL,
	[date_last_update] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[paycondition_id] ASC,
	[instalment_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BILLSTOPAY]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BILLSTOPAY](
	[billNumber] [int] NOT NULL,
	[billModel] [int] NOT NULL,
	[billSeries] [int] NOT NULL,
	[billPage] [int] NOT NULL,
	[instalmentNumber] [int] NOT NULL,
	[instalmentsQtd] [int] NOT NULL,
	[dueDate] [date] NOT NULL,
	[emissionDate] [date] NOT NULL,
	[isPaid] [int] NOT NULL,
	[paidDate] [date] NULL,
	[BillValue] [decimal](10, 2) NOT NULL,
	[payCondition_id] [int] NOT NULL,
	[supplier_id] [int] NOT NULL,
	[purchase_id] [int] NOT NULL,
	[date_creation] [datetime] NOT NULL,
	[date_last_update] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[billNumber] ASC,
	[billModel] ASC,
	[billSeries] ASC,
	[billPage] ASC,
	[instalmentNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BILLSTORECEIVE]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BILLSTORECEIVE](
	[sale_id] [int] NOT NULL,
	[instalmentNumber] [int] NOT NULL,
	[instalmentValue] [decimal](18, 0) NOT NULL,
	[isPaid] [int] NOT NULL,
	[client_id] [int] NOT NULL,
	[paycondition_id] [int] NOT NULL,
	[instalmentsQtd] [int] NOT NULL,
	[dueDate] [date] NOT NULL,
	[emissionDate] [date] NOT NULL,
	[date_creation] [date] NOT NULL,
	[date_last_update] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[sale_id] ASC,
	[instalmentNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BRANDS]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BRANDS](
	[id_brand] [int] IDENTITY(2,1) NOT NULL,
	[brand_name] [varchar](30) NOT NULL,
	[date_creation] [datetime] NOT NULL,
	[date_last_update] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_brand] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CITIES]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CITIES](
	[id_city] [int] IDENTITY(2,1) NOT NULL,
	[city_name] [varchar](50) NOT NULL,
	[city_phone_prefix] [varchar](4) NULL,
	[state_id] [int] NULL,
	[date_creation] [datetime] NOT NULL,
	[date_last_update] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_city] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLIENTS]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTS](
	[id_client] [int] IDENTITY(2,1) NOT NULL,
	[client_name] [varchar](50) NOT NULL,
	[client_gender] [int] NOT NULL,
	[client_registration] [varchar](14) NULL,
	[client_age] [int] NOT NULL,
	[client_dob] [datetime] NOT NULL,
	[client_email] [varchar](30) NOT NULL,
	[client_phone1] [varchar](12) NOT NULL,
	[client_phone2] [varchar](12) NULL,
	[client_phone3] [varchar](12) NULL,
	[client_phone_class1] [int] NOT NULL,
	[client_phone_class2] [int] NULL,
	[client_phone_class3] [int] NULL,
	[CLIENT_STREET_NAME] [varchar](50) NOT NULL,
	[CLIENT_DISTRICT] [varchar](50) NOT NULL,
	[CLIENT_HOUSE_NUMBER] [varchar](10) NOT NULL,
	[CLIENT_HOME_TYPE] [varchar](15) NOT NULL,
	[CLIENT_COMPLEMENT] [varchar](30) NULL,
	[CLIENT_ZIP_CODE] [varchar](10) NOT NULL,
	[city_id] [int] NOT NULL,
	[client_type] [int] NOT NULL,
	[date_creation] [datetime] NOT NULL,
	[date_last_update] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_client] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COUNTRIES]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COUNTRIES](
	[id_country] [int] IDENTITY(2,1) NOT NULL,
	[country_name] [varchar](50) NOT NULL,
	[country_acronym] [varchar](3) NOT NULL,
	[country_phonePrefix] [varchar](4) NULL,
	[country_currency] [varchar](10) NULL,
	[date_creation] [datetime] NOT NULL,
	[date_last_update] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_country] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPLOYEES]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPLOYEES](
	[id_employee] [int] IDENTITY(2,1) NOT NULL,
	[employee_name] [varchar](50) NOT NULL,
	[employee_gender] [int] NOT NULL,
	[employee_age] [int] NOT NULL,
	[employee_registration] [varchar](14) NULL,
	[employee_dob] [datetime] NOT NULL,
	[employee_email] [varchar](30) NOT NULL,
	[employee_phone1] [varchar](12) NOT NULL,
	[employee_phone2] [varchar](12) NULL,
	[employee_phone3] [varchar](12) NULL,
	[employee_phone_class1] [int] NOT NULL,
	[employee_phone_class2] [int] NULL,
	[employee_phone_class3] [int] NULL,
	[street_name] [varchar](50) NOT NULL,
	[district] [varchar](50) NOT NULL,
	[house_number] [varchar](10) NOT NULL,
	[complement] [varchar](30) NULL,
	[zipcode] [varchar](10) NOT NULL,
	[id_city] [int] NULL,
	[jobRole] [varchar](30) NOT NULL,
	[baseSalary] [decimal](10, 2) NOT NULL,
	[weeklyHours] [int] NOT NULL,
	[employee_status] [int] NOT NULL,
	[admission_date] [datetime] NOT NULL,
	[dismissed_date] [datetime] NULL,
	[home_type] [varchar](15) NOT NULL,
	[date_creation] [datetime] NOT NULL,
	[date_last_update] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_employee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OSITEMS]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OSITEMS](
	[ID_OSITEM] [int] IDENTITY(2,1) NOT NULL,
	[OS_ID] [int] NULL,
	[PRODUCT_ID] [int] NOT NULL,
	[QUANTITY] [int] NOT NULL,
	[SALE_VALUE] [decimal](18, 0) NOT NULL,
	[DISCOUNT] [decimal](18, 0) NOT NULL,
	[TOTAL_VALUE] [decimal](18, 0) NOT NULL,
	[DATE_CREATION] [date] NOT NULL,
	[DATE_LAST_UPDATE] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_OSITEM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PAYMENTCONDITIONS]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAYMENTCONDITIONS](
	[id_paycondition] [int] IDENTITY(2,1) NOT NULL,
	[condition_name] [varchar](30) NOT NULL,
	[payment_fees] [decimal](10, 2) NOT NULL,
	[fine_value] [decimal](10, 2) NOT NULL,
	[discount_perc] [decimal](10, 2) NULL,
	[instalment_quantity] [int] NOT NULL,
	[date_creation] [datetime] NOT NULL,
	[date_last_update] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_paycondition] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PAYMENTMETHODS]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAYMENTMETHODS](
	[id_payment_method] [int] IDENTITY(2,1) NOT NULL,
	[payment_method] [varchar](30) NOT NULL,
	[date_creation] [datetime] NOT NULL,
	[date_last_update] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_payment_method] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONECLASSIFICATIONS]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONECLASSIFICATIONS](
	[id_phoneClassification] [int] IDENTITY(2,1) NOT NULL,
	[phoneClassification_name] [varchar](20) NOT NULL,
	[date_creation] [datetime] NOT NULL,
	[date_last_update] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_phoneClassification] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCTGROUPS]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTGROUPS](
	[id_product_group] [int] IDENTITY(2,1) NOT NULL,
	[product_group] [varchar](30) NOT NULL,
	[description_product_group] [varchar](30) NULL,
	[date_creation] [datetime] NOT NULL,
	[date_last_update] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_product_group] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCTS]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTS](
	[id_product] [int] IDENTITY(2,1) NOT NULL,
	[product_name] [varchar](50) NOT NULL,
	[product_sale_price] [decimal](10, 2) NOT NULL,
	[product_group_id] [int] NULL,
	[brand_id] [int] NULL,
	[stock] [int] NOT NULL,
	[product_cost] [decimal](10, 2) NOT NULL,
	[product_barcode] [bigint] NULL,
	[date_creation] [datetime] NOT NULL,
	[date_last_update] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PURCHASEITEMS]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PURCHASEITEMS](
	[ID_PURCHASE] [int] NOT NULL,
	[PRODUCT_ID] [int] NOT NULL,
	[QUANTITY] [int] NOT NULL,
	[ITEM_VALUE] [decimal](18, 0) NOT NULL,
	[ITEM_COST] [decimal](18, 0) NOT NULL,
	[DISCOUNT_CASH] [decimal](18, 0) NOT NULL,
	[DISCOUNT_PERC] [decimal](18, 0) NOT NULL,
	[TOTAL_VALUE] [decimal](18, 0) NOT NULL,
	[DATE_CREATION] [date] NOT NULL,
	[DATE_LAST_UPDATE] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_PURCHASE] ASC,
	[PRODUCT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PURCHASES]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PURCHASES](
	[id_purchase] [int] IDENTITY(2,1) NOT NULL,
	[purchaseStatus] [int] NOT NULL,
	[emissionDate] [date] NOT NULL,
	[arrivalDate] [date] NULL,
	[freightCost] [decimal](18, 0) NULL,
	[purchase_TotalCost] [decimal](18, 0) NOT NULL,
	[purchase_TotalValue] [decimal](18, 0) NOT NULL,
	[purchase_ExtraExpenses] [decimal](18, 0) NULL,
	[purchase_DiscountCash] [decimal](18, 0) NULL,
	[purchase_DiscountPerc] [decimal](18, 0) NULL,
	[purchase_InsuranceCost] [decimal](18, 0) NULL,
	[paycondition_id] [int] NOT NULL,
	[supplier_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[date_creation] [datetime] NOT NULL,
	[date_last_update] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_purchase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SALEITEMS]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SALEITEMS](
	[SALE_ID] [int] NOT NULL,
	[PRODUCT_ID] [int] NOT NULL,
	[QUANTITY] [int] NOT NULL,
	[ITEM_VALUE] [decimal](18, 0) NOT NULL,
	[ITEM_COST] [decimal](18, 0) NOT NULL,
	[DISCOUNT_CASH] [decimal](18, 0) NOT NULL,
	[DISCOUNT_PERC] [decimal](18, 0) NOT NULL,
	[TOTAL_VALUE] [decimal](18, 0) NOT NULL,
	[DATE_CREATION] [date] NOT NULL,
	[DATE_LAST_UPDATE] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SALE_ID] ASC,
	[PRODUCT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SALES]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SALES](
	[id_sale] [int] IDENTITY(2,1) NOT NULL,
	[CLIENT_ID] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[sale_total_cost] [decimal](18, 0) NOT NULL,
	[sale_total_value] [decimal](18, 0) NOT NULL,
	[sale_DISCOUNT_CASH] [decimal](18, 0) NOT NULL,
	[sale_DISCOUNT_PERC] [decimal](18, 0) NOT NULL,
	[total_Items_Quantity] [int] NOT NULL,
	[sale_cancel_date] [datetime] NULL,
	[date_creation] [datetime] NOT NULL,
	[date_last_update] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_sale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SERVICEORDERS]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SERVICEORDERS](
	[id_serviceOrder] [int] IDENTITY(2,1) NOT NULL,
	[so_equipment] [varchar](50) NOT NULL,
	[service_id] [int] NOT NULL,
	[client_id] [int] NOT NULL,
	[userid] [int] NOT NULL,
	[extra_details] [varchar](250) NULL,
	[so_cost] [decimal](18, 0) NULL,
	[so_value] [decimal](18, 0) NULL,
	[so_completedate] [datetime] NULL,
	[so_canceldate] [datetime] NULL,
	[so_discount_cash] [decimal](18, 0) NULL,
	[so_discount_perc] [decimal](18, 0) NULL,
	[date_creation] [datetime] NOT NULL,
	[date_last_update] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_serviceOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SERVICES]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SERVICES](
	[id_service] [int] IDENTITY(2,1) NOT NULL,
	[desc_service] [varchar](100) NOT NULL,
	[service_value] [decimal](10, 2) NOT NULL,
	[date_creation] [datetime] NOT NULL,
	[date_last_update] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_service] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SOINSTALMENTS]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SOINSTALMENTS](
	[paycondition_id] [int] NOT NULL,
	[numberInstalment] [int] NOT NULL,
	[serviceOrder_id] [int] NOT NULL,
	[instalment_value] [decimal](18, 0) NOT NULL,
	[pay_status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[serviceOrder_id] ASC,
	[numberInstalment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STATES]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STATES](
	[id_state] [int] IDENTITY(2,1) NOT NULL,
	[state_name] [varchar](50) NOT NULL,
	[state_fed_unit] [varchar](3) NOT NULL,
	[id_country] [int] NULL,
	[date_creation] [datetime] NOT NULL,
	[date_last_update] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_state] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SUPPLIERPRODUCTS]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SUPPLIERPRODUCTS](
	[id_product] [int] NOT NULL,
	[id_supplier] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_product] ASC,
	[id_supplier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SUPPLIERS]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SUPPLIERS](
	[id_supplier] [int] IDENTITY(2,1) NOT NULL,
	[supplier_registration] [varchar](14) NULL,
	[supplier_name] [varchar](50) NOT NULL,
	[supplier_social_reason] [varchar](50) NULL,
	[supplier_state_inscription] [varchar](9) NOT NULL,
	[supplier_email] [varchar](30) NOT NULL,
	[supplier_phone1] [varchar](12) NOT NULL,
	[supplier_phone2] [varchar](12) NULL,
	[supplier_phone3] [varchar](12) NULL,
	[supplier_phone_class1] [int] NOT NULL,
	[supplier_phone_class2] [int] NULL,
	[supplier_phone_class3] [int] NULL,
	[supplier_STREET_NAME] [varchar](50) NOT NULL,
	[supplier_DISTRICT] [varchar](50) NOT NULL,
	[supplier_HOUSE_NUMBER] [varchar](10) NOT NULL,
	[supplier_HOME_TYPE] [varchar](15) NOT NULL,
	[supplier_COMPLEMENT] [varchar](30) NULL,
	[supplier_ZIP_CODE] [varchar](10) NOT NULL,
	[city_id] [int] NOT NULL,
	[date_creation] [datetime] NOT NULL,
	[date_last_update] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_supplier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 10/05/2023 02:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERS](
	[id_user] [int] IDENTITY(2,1) NOT NULL,
	[employee_id] [int] NULL,
	[userLogin] [varchar](15) NOT NULL,
	[userPassword] [varchar](15) NOT NULL,
	[levelAccess] [int] NOT NULL,
	[date_creation] [datetime] NOT NULL,
	[date_last_update] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BILLSINSTALMENTS]  WITH CHECK ADD FOREIGN KEY([paycondition_id])
REFERENCES [dbo].[PAYMENTCONDITIONS] ([id_paycondition])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BILLSINSTALMENTS]  WITH CHECK ADD FOREIGN KEY([paymethod_id])
REFERENCES [dbo].[PAYMENTMETHODS] ([id_payment_method])
GO
ALTER TABLE [dbo].[BILLSTOPAY]  WITH CHECK ADD FOREIGN KEY([payCondition_id])
REFERENCES [dbo].[PAYMENTCONDITIONS] ([id_paycondition])
GO
ALTER TABLE [dbo].[BILLSTOPAY]  WITH CHECK ADD FOREIGN KEY([purchase_id])
REFERENCES [dbo].[PURCHASES] ([id_purchase])
GO
ALTER TABLE [dbo].[BILLSTOPAY]  WITH CHECK ADD FOREIGN KEY([supplier_id])
REFERENCES [dbo].[SUPPLIERS] ([id_supplier])
GO
ALTER TABLE [dbo].[BILLSTORECEIVE]  WITH CHECK ADD FOREIGN KEY([client_id])
REFERENCES [dbo].[CLIENTS] ([id_client])
GO
ALTER TABLE [dbo].[BILLSTORECEIVE]  WITH CHECK ADD FOREIGN KEY([paycondition_id])
REFERENCES [dbo].[PAYMENTCONDITIONS] ([id_paycondition])
GO
ALTER TABLE [dbo].[BILLSTORECEIVE]  WITH CHECK ADD FOREIGN KEY([sale_id])
REFERENCES [dbo].[SALES] ([id_sale])
GO
ALTER TABLE [dbo].[CITIES]  WITH CHECK ADD FOREIGN KEY([state_id])
REFERENCES [dbo].[STATES] ([id_state])
GO
ALTER TABLE [dbo].[CLIENTS]  WITH CHECK ADD FOREIGN KEY([city_id])
REFERENCES [dbo].[CITIES] ([id_city])
GO
ALTER TABLE [dbo].[CLIENTS]  WITH CHECK ADD FOREIGN KEY([client_phone_class1])
REFERENCES [dbo].[PHONECLASSIFICATIONS] ([id_phoneClassification])
GO
ALTER TABLE [dbo].[CLIENTS]  WITH CHECK ADD FOREIGN KEY([client_phone_class2])
REFERENCES [dbo].[PHONECLASSIFICATIONS] ([id_phoneClassification])
GO
ALTER TABLE [dbo].[CLIENTS]  WITH CHECK ADD FOREIGN KEY([client_phone_class3])
REFERENCES [dbo].[PHONECLASSIFICATIONS] ([id_phoneClassification])
GO
ALTER TABLE [dbo].[EMPLOYEES]  WITH CHECK ADD FOREIGN KEY([employee_phone_class1])
REFERENCES [dbo].[PHONECLASSIFICATIONS] ([id_phoneClassification])
GO
ALTER TABLE [dbo].[EMPLOYEES]  WITH CHECK ADD FOREIGN KEY([employee_phone_class2])
REFERENCES [dbo].[PHONECLASSIFICATIONS] ([id_phoneClassification])
GO
ALTER TABLE [dbo].[EMPLOYEES]  WITH CHECK ADD FOREIGN KEY([employee_phone_class3])
REFERENCES [dbo].[PHONECLASSIFICATIONS] ([id_phoneClassification])
GO
ALTER TABLE [dbo].[EMPLOYEES]  WITH CHECK ADD FOREIGN KEY([id_city])
REFERENCES [dbo].[CITIES] ([id_city])
GO
ALTER TABLE [dbo].[OSITEMS]  WITH CHECK ADD FOREIGN KEY([OS_ID])
REFERENCES [dbo].[SALES] ([id_sale])
GO
ALTER TABLE [dbo].[OSITEMS]  WITH CHECK ADD FOREIGN KEY([PRODUCT_ID])
REFERENCES [dbo].[PRODUCTS] ([id_product])
GO
ALTER TABLE [dbo].[PRODUCTS]  WITH CHECK ADD FOREIGN KEY([brand_id])
REFERENCES [dbo].[BRANDS] ([id_brand])
GO
ALTER TABLE [dbo].[PRODUCTS]  WITH CHECK ADD FOREIGN KEY([product_group_id])
REFERENCES [dbo].[PRODUCTGROUPS] ([id_product_group])
GO
ALTER TABLE [dbo].[PURCHASEITEMS]  WITH CHECK ADD FOREIGN KEY([ID_PURCHASE])
REFERENCES [dbo].[PURCHASES] ([id_purchase])
GO
ALTER TABLE [dbo].[PURCHASEITEMS]  WITH CHECK ADD FOREIGN KEY([PRODUCT_ID])
REFERENCES [dbo].[PRODUCTS] ([id_product])
GO
ALTER TABLE [dbo].[PURCHASES]  WITH CHECK ADD FOREIGN KEY([paycondition_id])
REFERENCES [dbo].[PAYMENTCONDITIONS] ([id_paycondition])
GO
ALTER TABLE [dbo].[PURCHASES]  WITH CHECK ADD FOREIGN KEY([supplier_id])
REFERENCES [dbo].[SUPPLIERS] ([id_supplier])
GO
ALTER TABLE [dbo].[PURCHASES]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[USERS] ([id_user])
GO
ALTER TABLE [dbo].[SALEITEMS]  WITH CHECK ADD FOREIGN KEY([PRODUCT_ID])
REFERENCES [dbo].[PRODUCTS] ([id_product])
GO
ALTER TABLE [dbo].[SALEITEMS]  WITH CHECK ADD FOREIGN KEY([SALE_ID])
REFERENCES [dbo].[SALES] ([id_sale])
GO
ALTER TABLE [dbo].[SALES]  WITH CHECK ADD FOREIGN KEY([CLIENT_ID])
REFERENCES [dbo].[CLIENTS] ([id_client])
GO
ALTER TABLE [dbo].[SALES]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[USERS] ([id_user])
GO
ALTER TABLE [dbo].[SERVICEORDERS]  WITH CHECK ADD FOREIGN KEY([client_id])
REFERENCES [dbo].[CLIENTS] ([id_client])
GO
ALTER TABLE [dbo].[SERVICEORDERS]  WITH CHECK ADD FOREIGN KEY([service_id])
REFERENCES [dbo].[SERVICES] ([id_service])
GO
ALTER TABLE [dbo].[SERVICEORDERS]  WITH CHECK ADD FOREIGN KEY([userid])
REFERENCES [dbo].[USERS] ([id_user])
GO
ALTER TABLE [dbo].[SOINSTALMENTS]  WITH CHECK ADD FOREIGN KEY([paycondition_id])
REFERENCES [dbo].[PAYMENTCONDITIONS] ([id_paycondition])
GO
ALTER TABLE [dbo].[SOINSTALMENTS]  WITH CHECK ADD FOREIGN KEY([serviceOrder_id])
REFERENCES [dbo].[SERVICEORDERS] ([id_serviceOrder])
GO
ALTER TABLE [dbo].[STATES]  WITH CHECK ADD FOREIGN KEY([id_country])
REFERENCES [dbo].[COUNTRIES] ([id_country])
GO
ALTER TABLE [dbo].[SUPPLIERPRODUCTS]  WITH CHECK ADD FOREIGN KEY([id_product])
REFERENCES [dbo].[PRODUCTS] ([id_product])
GO
ALTER TABLE [dbo].[SUPPLIERPRODUCTS]  WITH CHECK ADD FOREIGN KEY([id_supplier])
REFERENCES [dbo].[SUPPLIERS] ([id_supplier])
GO
ALTER TABLE [dbo].[SUPPLIERS]  WITH CHECK ADD FOREIGN KEY([city_id])
REFERENCES [dbo].[CITIES] ([id_city])
GO
ALTER TABLE [dbo].[SUPPLIERS]  WITH CHECK ADD FOREIGN KEY([supplier_phone_class1])
REFERENCES [dbo].[PHONECLASSIFICATIONS] ([id_phoneClassification])
GO
ALTER TABLE [dbo].[SUPPLIERS]  WITH CHECK ADD FOREIGN KEY([supplier_phone_class2])
REFERENCES [dbo].[PHONECLASSIFICATIONS] ([id_phoneClassification])
GO
ALTER TABLE [dbo].[SUPPLIERS]  WITH CHECK ADD FOREIGN KEY([supplier_phone_class3])
REFERENCES [dbo].[PHONECLASSIFICATIONS] ([id_phoneClassification])
GO
ALTER TABLE [dbo].[USERS]  WITH CHECK ADD FOREIGN KEY([employee_id])
REFERENCES [dbo].[EMPLOYEES] ([id_employee])
GO
