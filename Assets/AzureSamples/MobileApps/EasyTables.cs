using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using UnityEngine;

public class EasyTables : BaseMobileApps
{
	public async void EasyTablesTest()
	{
		ClearOutput();
		WriteLine("-- Testing Easy Tables --");

		WriteLine("Getting table");
		IMobileServiceTable<TodoItem> tbl = Client.GetTable<TodoItem>();

		WriteLine("Inserting new item");
		try
		{
			await tbl.InsertAsync(new TodoItem { Text = "New item" });

			WriteLine("Getting unfinished items");
			List<TodoItem> list = await tbl.Where(i => i.Complete == false).ToListAsync();
			foreach(TodoItem item in list)
				WriteLine($"{item.Id} - {item.Text} - {item.Complete}");

			WriteLine("Updating first item");
			list[0].Complete = true;
			await tbl.UpdateAsync(list[0]);

			WriteLine("Deleting first item");
			await tbl.DeleteAsync(list[0]);
		}
		catch(Exception e)
		{
			WriteLine(e.ToString());
		}

		WriteLine("-- Test Complete --");
	}
}
