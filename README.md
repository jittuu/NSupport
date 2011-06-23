# NSupport

A .Net port of ActiveSupport library of Ruby on Rails. The goal is to extend Base Class Library for Common Usage with human readable syntax.

# Installation

### Nuget
> Install-Package NSupport

More information about nuget package at http://www.nuget.org/List/Packages/NSupport.

### DLL download
You can download the latest release dll from [**Here**](https://github.com/downloads/soemoe/NSupport/NSupport%20v1.1.zip) and add reference to your project.

# Usage

**NSupport** extends the BCL by adding extension methods, so you need to add the using reference to your code.

```c#
    using NSupport;
```

NSupport extends [DateTime](http://msdn.microsoft.com/en-us/library/system.datetime.aspx) to allow you to write as below and more:

```c#
	var june18 = new DateTime(2011,6,18);
		
	june18.Tomorrow(); // 2011/06/19
	
	june18.Yesterday(); // 2011/06/17
	
	june18.Nextyear(); // 2012/06/18
	
	june18.EndOfDay(); // 2011/06/18 23:59:59
	
	june18.BeginnerOfMonth(); // 2011/06/01
	
	june18.EndOfMonth(); // 2011/06/30 23:59:59
	
	june18.BeginningOfWeek(); // 2011/06/12
	
	june18.NextWeek(DayOfWeek.Friday); // 2011/06/24
	
	june18.BeginningOfQuarter(); // 2011/04/01
	
	june18.IsToday(); // true if today is june 18 2011 regardless of time
	
	june18.Change(years: 2010); // 2010/06/18
```

and also extends [Integer](http://msdn.microsoft.com/en-us/library/system.int32.aspx) to enable to write as:

```c#
	2.IsEven(); // true
	1.IsEven(); // false
	0.IsOdd(); // false
	
	15.IsMultipleOf(3); // true
	
	1.Byte(); // 1
	1.Kilobyte(); // 1024
	2.Megabytes(); // 2*1024*1024
```

and when [Integer](http://msdn.microsoft.com/en-us/library/system.int32.aspx) love [TimeSpan](http://msdn.microsoft.com/en-us/library/system.timespan.aspx)

```c#
	1.Hour(); // Timespan of 1 hour
	30.Minutes().Ago(); // 30 minutes ago 
	(2.Hours() + 20.Minutes()).FromNow();  // 2 hours and 20 minutes from now
	
	10.Hours().Since(new DateTime(2011,6,18)); // 2011/06/18 10:00:00
```

# CONTRIBUTE

If you want to hack NSupport, start by forking my repo on GitHub:

https://github.com/soemoe/nsupport