class Data:
    country_valid_json = {
        "CountryName": "123",
        "CountryCode": 1112,
        "NatLangCode": 332,
        "CurrencyCode": "123",
        "Currency": "dollar"
    }

    country_invalid_json = {
        "CountryName": "",
        "CountryCode": 0,
        "NatLangCode": 332,
        "CurrencyCode": "",
        "Currency": "dollar"
    }

    customer_company_valid_json = {
        "CompanyName": "fafafa",
        "CreditLimitCurrency": "dolls",
        "CompanyCreditLimit": 100000000
    }

    customer_company_invalid_json = {
        "CompanyName": "",
        "CreditLimitCurrency": "dolls",
        "CompanyCreditLimit": 0
    }

    customer_employee_valid_json = {
        "BadgeNumber": "asd123",
        "JobTitle": "Programmer",
        "Department": "IT",
        "CreditLimit": 10000,
        "CreditLimitCurrency":"uhanies"
    }

    customer_employee_invalid_json = {
        "BadgeNumber": "",
        "JobTitle": "",
        "Department": "IT",
        "CreditLimit": 10000,
        "CreditLimitCurrency": ""
    }

    customer_valid_json = {
        "AccountMgrId": 123,
        "IncomeLevel": 133
    }

    customer_invalid_json = {
        "AccountMgrId": 123
    }

    employment_jobs_valid_json = {
        "JobTitle": "God",
        "MinSalary": 1,
        "MaxSalary": 2
    }

    employment_jobs_invalid_json = {
        "JobTitle": "",
        "MaxSalary": 2
    }

    phone_number_valid_json = {
        "Phonenumber": 7788,
        "CountryCode": 123,
        "PhoneType": 111
    }

    phone_number_invalid_json = {
        "Phonenumber": 7788,
        "CountryCode": 123,
        "PhoneType": 111
    }

    employment_valid_json = {
        "StartDate": "1.01.2020",
        "EndDate:": "07.01.2020",
        "Salary": 2000,
        "CommissionPercent": "3",
        "Employmentcol": "fafafa"
    }

    employment_invalid_json = {
        "StartDate": "",
        "EndDate:": "07.01.2020",
        "Salary": 2000,
        "CommissionPercent": "",
        "Employmentcol": ""
    }

    inventory_valid_json = {
        "WarehouseId": 111,
        "QuantityAvaliable": 123,
        "QuantityOnHand": 333
    }

    inventory_invalid_json = {
        "QuantityOnHand": 333
    }

    location_valid_json = {
        "CountryId": 12,
        "AdressLine1": "fafafa",
        "AdressLine2": "jajaja",
        "City": "Minsk",
        "State": "California",
        "District": "memeonmeme",
        "PostalCode": "asdf",
        "LocationTypeCode": 444555,
        "Description": "Have a nice day!",
        "ShippingNotes": "Do not break nothing",
        "CountriesCountryId": 44
    }

    location_invalid_json = {
        "CountryId": 12,
        "AdressLine1": "fafafa",
        "AdressLine2": "jajaja",
        "ShippingNotes": "Do not break nothing",
        "CountriesCountryId": 44
    }

    order_item_valid_json = {
        "OrderItemId:": 1,
        "OrderId": 12,
        "ProductId": 123,
        "UnitPrice": 22.22,
        "Quantity": 123.123,
    }

    order_item_invalid_json = {
        "OrderItemId:": 1,
        "Quantity": 123.123,
    }

    orders_valid_json = {
        "OrderId": 1,
        "CustomerId": 123,
        "SalesRepId": 123,
        "OrderDate": "today",
        "OrderCode": 228,
        "OrderStatus": "nice",
        "OrderTotal": 6000,
        "OrderCurrency": "dolls",
        "PromotionCode": "FFAAQQ"
    }

    orders_invalid_json = {
        "OrderId": 1,
        "CustomerId": 123,
        "SalesRepId": 123,
        "OrderDate": "today",
    }

    person_valid_json = {
        "FirstName": "Oleg",
        "LastName": "Olegivi4",
        "MiddleName": "OlehHHH",
        "Nickname": "Alexa",
        "CultureCode": 22999,
        "Gender": "female"
    }

    person_invalid_json = {
        "FirstName": "Oleg",
        "Gender": "female"
    }

    person_location_valid_json = {
        "SubAdress": "this is my real adreess. call me later",
        "LocationUsage": "Everywhere",
        "Notes": "notes"
    }

    person_location_invalid_json = {
        "SubAdress": "this is my real adreess. call me later",
        "Notes": "notes"
    }

    product_valid_json = {
        "ProductName": "Milk",
        "Description": "From alive cow",
        "Category": 3,
        "WeightClass": 900,
        "WarrantlyPeriod": 3,
        "SupplierId": 123,
        "Status": "Looking good",
        "ListPrice": 150,
        "MinimumPrice": 11,
        "PriceCurrency": "BYN",
        "CatalogURL": "https:\\myrealshop.com\\milkfromrealcow"
    }

    product_invalid_json = {
        "ProductName": "Milk",
        "Status": "Looking good",
        "ListPrice": 150,
        "MinimumPrice": 11,
        "PriceCurrency": "BYN",
        "CatalogURL": "https:\\myrealshop.com\\milkfromrealcow"
    }

    restricted_valid_json = {
        "DateOfBirth": "13.12.2001",
        "DateOfDeath": "unknown",
        "GovernmentId": "why Id is string?",
        "PassportId": "MP12333",
        "HireDire": "what is it",
        "SeniorityCode": 112233
    }

    restricted_invalid_json = {
        "DateOfBirth": "13.12.2001",
        "DateOfDeath": "unknown",
        "GovernmentId": "why Id is string?"
    }

    warehouse_valid_json = {
        "WarehouseName": "MyWarehouseWithMilk"
    }

    warehouse_invalid_json = {}