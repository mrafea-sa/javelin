﻿using System.Linq;
using Javelin.Base.Config;
using Javelin.Base.Tasks;

namespace Javelin.ScheduledTasks
{
	internal class TaskCronJobSchedulerConfig : BaseConfig, ITaskCronJobSchedulerConfig
	{
		public TaskCronJobSchedulerConfig(IConfigReader configReader)
			: base(configReader)
		{
		}

		public bool HasScheduler
		{
			get { return configReader.GetSubconfigs("scheduler").Any(); }
		}

		public ISchedulerConfig[] Scheduler
		{
			get
			{
				return configReader
					.GetSubconfigs("scheduler")
					.Select(cr => new SchedulerConfig(cr))
					.Cast<ISchedulerConfig>()
					.ToArray();
			}
		}

		public ITaskConfig[] Tasks
		{
			get
			{
				return configReader
					.GetSubconfigs("tasks")
					.Select(cr => new TaskConfig(cr))
					.Cast<ITaskConfig>()
					.ToArray();
			}
		}
	}
}