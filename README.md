# Sheila Accounting Application

A Windows desktop accounting application written in C# with Windows Forms by Ryad Abdelgalil.

Sheila began as a Visual Basic Microsoft Access application and was used as the basis for this C# migration exercise. The current implementation uses Microsoft Jet OLEDB to open a Microsoft Access `.mdb` database and exposes basic reference-data management through a desktop interface.

## Features

- View and manage projects
- Manage voucher data
- Manage debit and credit types
- Manage clients
- Manage beneficiaries
- Manage accounts
- Browse records in `DataGridView` controls
- Add, edit, and delete records
- Re-link the application to a different Access database file
- Multiple WinForms screens for the available accounting modules

## Main Modules

- **Your Project / Companies:** company and address information
- **Vouchers:** voucher records
- **Projects:** project records
- **Debit / Credit Types:** expense or accounting types
- **Clients:** client information
- **Beneficiaries:** beneficiary information
- **Accounts:** account names and references
- **Reports:** reserved for future reporting functionality

## Technology

- C#
- .NET Framework 4.5
- Windows Forms
- Microsoft Jet OLEDB
- Microsoft Access `.mdb` database
- Visual Studio 2013 solution format
- Microsoft ReportViewer assemblies referenced by the project

## Database

The application currently uses a Microsoft Access database through `OleDbConnection`:

```text
Provider=Microsoft.Jet.OLEDB.4.0
Data Source=C:\Data\Target\Sheila\SheilaData.mdb
